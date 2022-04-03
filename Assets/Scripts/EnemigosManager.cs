using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosManager : MonoBehaviour
{
    public bool goLeft;
    public float speed;
    public int maxSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool run = false;
    private float timeCurrentAction = 0;
    private float actionDuration = 4f;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (run)
        {
            if (goLeft)
                MoveLeft();
            else
                MoveRight();
        }
    }

    private void FixedUpdate()
    {
        timeCurrentAction += Time.fixedDeltaTime;
        if(timeCurrentAction >= actionDuration)
        {
            rb.velocity = new Vector2();
            run = !run;
            anim.SetBool("Run", run);
            timeCurrentAction = 0;
            actionDuration = Random.Range(4f, 8f);
            if(run)
                goLeft = !goLeft;
        }
    }

    private void MoveRight()
    {
        var right = transform.right;
        if (rb.velocity.x < maxSpeed)
            rb.velocity += new Vector2(right.x * speed, right.y) * Time.deltaTime * speed;
        sprite.flipX = true;
    }

    private void MoveLeft()
    {
        var right = transform.right;
        if (rb.velocity.x > -maxSpeed)
            rb.velocity -= new Vector2(right.x * speed, right.y) * Time.deltaTime * speed;
        sprite.flipX = false;
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        var right = transform.right;
    //        rb.velocity = new Vector2(0, 0);
    //        if (goLeft)
    //            rb.position = new Vector2(rb.position.x + 0.07f, rb.position.y);
    //        else
    //            rb.position = new Vector2(rb.position.x - 0.07f, rb.position.y);
    //        goLeft = !goLeft;

    //    }
    //}
}
