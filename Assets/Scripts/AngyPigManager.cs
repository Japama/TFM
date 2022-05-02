using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngyPigManager : MonoBehaviour
{

    public float speed;
    public int maxSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool run = false;
    private float timeCurrentAction = 0;
    private float actionDuration = 4f;
    private Animator anim;
    private bool turn;

    private WarningZoneController warningZoneController;

    [SerializeField]
    private bool goLeft;

    // Start is called before the first frame update
    void Start()
    {
        warningZoneController = GetComponentInParent<WarningZoneController>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (turn)
            Turn();

        if (run)
            Move();
    }

    private void FixedUpdate()
    {
        timeCurrentAction += Time.fixedDeltaTime;
        if (timeCurrentAction >= actionDuration)
        {
            StartStop();
            timeCurrentAction = 0;
            actionDuration = Random.Range(4f, 8f);
            if (run)
            {
                turn = true;
                goLeft = !goLeft;
            }
        }
    }

    private void StartStop()
    {
        rb.velocity = new Vector2();
        run = !run;
        anim.SetBool("Run", run);
    }

    private void Move()
    {
        var right = transform.right;
        if (rb.velocity.x > -maxSpeed && rb.velocity.x < maxSpeed)
            rb.velocity += speed * Time.deltaTime * new Vector2(right.x * speed, right.y);
    }

    private void Turn()
    {
        transform.eulerAngles = transform.eulerAngles + 180f * Vector3.up;
        turn = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!gameObject.CompareTag("WeakPoint") && !gameObject.CompareTag("DashWeakPoint"))
        {
            StartStop();
            int direction = goLeft ? 1 : -1;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.2f * direction, gameObject.transform.position.y, gameObject.transform.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión");
    }


    private void OnDestroy()
    {
        warningZoneController.DeleteEnemy(gameObject);
    }
}
