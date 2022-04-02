using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float LinearSpeed = 10;
    public float jumpForce = 8f;
    public float maxSpeed = 5f;
    public float dashSpeed;
    //public GameObject bullet;

    [SerializeField] private LayerMask sueloLayerMask;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private bool loockAtRigth = true;
    private PolygonCollider2D collider2D;

    private SpriteRenderer dashSprite;
    private Transform dashTransform;

    private bool dash = false;
    private bool dashCooldown = false;
    private float dashTime = 0f;
    private float dashChargeTime = 0.15f;
    private float dashCooldownTime = 1.5f;
    private float dashCurrentCooldown = 1.5f;
    private float dashDuration = 0.4f;

    //public Action OnKilled;
    //public Action OnReachedEndOfLevel;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        dashSprite = gameObject.GetComponentsInChildren<SpriteRenderer>().Where(s => s.CompareTag("Dash")).FirstOrDefault();
        dashTransform = dashSprite.gameObject.transform;
        anim = GetComponent<Animator>();
        collider2D = GetComponent<PolygonCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Correr", false);
        if (!dash)
        {
            if (IsFalling())
            {
                anim.SetBool("Caer", true);
                anim.SetBool("Saltar", false);
            }
            else
                anim.SetBool("Caer", false);

            if (!dashCooldown)
                if (Input.GetKey(KeyCode.Space))
                    ChargeDahs();
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
                MoveBackward();

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
                MoveForward();
            if (IsGrounded())
            {
                if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
                    Jump();
            }
        }
        else
        {
            if (dashTime > dashDuration)
            {

                dash = false;
                dashTime = 0;
                anim.SetBool("Cargar", false);
                dashCooldown = true;
                rb.velocity = new Vector2(0,0);
            }
            else
            {
                dashTime += Time.deltaTime;
            }
        }
        if (dashCooldown)
        {
            dashCurrentCooldown -= Time.deltaTime;
            if (dashCurrentCooldown <= 0)
            {
                dashCooldown = false;
                dashCurrentCooldown = dashCooldownTime;
            }

        }
    }

    private void ChargeDahs()
    {
        anim.SetBool("Cargar", true);
        dash = true;
        rb.velocity = new Vector2(0, 0);
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            if (dashTime > dashChargeTime)
                if (loockAtRigth)
                    rb.velocity = rb.transform.right * dashSpeed * Time.fixedDeltaTime;
                else
                    rb.velocity = rb.transform.right * dashSpeed * Time.fixedDeltaTime * -1;
        }
    }

    private void ExecuteDash()
    {

    }

    //private void ThrowAttack()
    //{
    //    float shotRight = loockAtRigth ? 1f : -1f;
    //    Vector3 bulletInitialPosition = new Vector3(this.transform.position.x + shotRight, this.transform.position.y);
    //    //var shot = Instantiate(bullet, bulletInitialPosition, this.transform.rotation);
    //    //shot.GetComponent<Rigidbody2D>().velocity = new Vector2(shotRight, 0f);
    //    canThrow = false;
    //    Invoke("RestoreCanThrow", 1.5f);
    //}

    //private void RestoreCanThrow()
    //{
    //    canThrow = true;
    //}

    private void MoveForward()
    {
        anim.SetBool("Correr", true);
        if (!loockAtRigth)
            dashTransform.localPosition = new Vector3(dashTransform.localPosition.x * -1, dashTransform.localPosition.y, dashTransform.localPosition.z);
        loockAtRigth = true;
        dashSprite.flipX = sprite.flipX = !loockAtRigth;
        var right = transform.right;
        if (rb.velocity.x < maxSpeed)
            rb.velocity += new Vector2(right.x * LinearSpeed, right.y * LinearSpeed) * Time.deltaTime;
    }

    private void MoveBackward()
    {
        anim.SetBool("Correr", true);
        if (loockAtRigth)
            dashTransform.localPosition = new Vector3(dashTransform.localPosition.x * -1, dashTransform.localPosition.y, dashTransform.localPosition.z);
        loockAtRigth = false;
        var right = transform.right;
        if (rb.velocity.x > -maxSpeed)
            rb.velocity -= new Vector2(right.x * LinearSpeed, right.y * LinearSpeed) * Time.deltaTime;
        dashSprite.flipX = sprite.flipX = !loockAtRigth;
    }

    private void Jump()
    {
        anim.SetBool("Saltar", true);
        var right = transform.right;
        Vector2 velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        velocity.y = jumpForce;
        rb.velocity = velocity;
        //SoundManager.PlaySound("Saltar");
    }

    private bool IsFalling()
    {
        return rb.velocity.y < -0.1;
    }

    private bool IsGrounded()
    {
        //return (Physics2D.Raycast(transform.position, Vector2.down, 0.5f, sueloLayerMask));
        float extraHeight = 0.1f;
        //RaycastHit2D raycast = Physics2D.Raycast(collider2D.bounds.center, Vector2.down, extraHeight, sueloLayerMask);
        RaycastHit2D raycast = Physics2D.BoxCast(collider2D.bounds.center, collider2D.bounds.size, 0f, Vector2.down, extraHeight, sueloLayerMask);
        Color rayColor = Color.red;
        if (raycast.collider != null)
            rayColor = Color.green;
        return raycast.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goomba" || other.gameObject.tag == "Water")
        {
            anim.SetBool("Dead", true);
            //OnKilled?.Invoke();
        }
        if (other.gameObject.tag == "Finish")
        {
            //OnReachedEndOfLevel?.Invoke();
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void Revive()
    {
        anim.SetBool("Dead", false);
    }
}
