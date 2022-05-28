using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngyPigManager : MonoBehaviour
{

    public float speed;
    public int maxWalkSpeed;
    public int maxRunSpeed;
    private Rigidbody2D rb;
    private bool run;
    private bool walk;
    private float timeCurrentAction = 0;
    private float actionDuration = 4f;
    private Animator anim;
    private bool turn;
    private bool immunity = false;

    private WarningZoneController warningZoneController;

    [SerializeField]
    private bool goLeft;

    // Start is called before the first frame update
    void Start()
    {
        warningZoneController = GetComponentInParent<WarningZoneController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        StartStop();
    }

    // Update is called once per frame
    void Update()
    {
        if (walk || run)
            Move();
    }

    private void FixedUpdate()
    {
        if (!run)
        {
            timeCurrentAction += Time.fixedDeltaTime;
            if (timeCurrentAction >= actionDuration)
            {
                StartStop();
                timeCurrentAction = 0;
                actionDuration = Random.Range(4f, 8f);
                if (walk)
                    Turn();
            }
        }
    }

    private void StartStop()
    {
        rb.velocity = new Vector2();
        if (!run)
        {
            walk = !walk;
            anim.SetBool("Walk", walk);
        }
    }

    private void Move()
    {

        var right = transform.right;
        if (walk)
        {
            if (rb.velocity.x > -maxWalkSpeed && rb.velocity.x < maxWalkSpeed)
                rb.velocity += speed * Time.deltaTime * new Vector2(right.x * speed, right.y);
        }
        else
        {
            if (rb.velocity.x > -maxRunSpeed && rb.velocity.x < maxRunSpeed)
                rb.velocity += speed * Time.deltaTime * new Vector2(right.x * speed, right.y);
        }
    }

    private void Turn()
    {
        rb.velocity = new Vector2();
        transform.eulerAngles = transform.eulerAngles + 180f * Vector3.up;
        turn = false;
        goLeft = !goLeft;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurnPoint"))
        {
            int direction = goLeft ? 1 : -1;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.2f * direction, gameObject.transform.position.y, gameObject.transform.position.z);
            if (walk)
                StartStop();
            if (run)
                Turn();
        }
    }

    private void OnDestroy()
    {
        warningZoneController.DeleteEnemy(gameObject);
    }


    public void Hitted()
    {
        SoundManager.PlaySound(SoundsEnum.EmemyHitted);
        if (run)
        {
            anim.SetTrigger("Hit2");
            transform.tag = "EnemyDeath";
        }
        else
        {

            anim.SetTrigger("Hit1");
            walk = false;
            run = true;
            immunity = true;
            Invoke(nameof(SetNotInmunity), 2.5f);
        }
    }

    private void SetNotInmunity()
    {
        immunity = false;
    }
}
