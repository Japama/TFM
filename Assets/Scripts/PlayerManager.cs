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

    [SerializeField] private LayerMask sueloLayerMask;

    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool loockAtRigth = true;
    private PolygonCollider2D collider2D;

    private SpriteRenderer dashSprite;
    private Transform dashTransform;

    private bool canClimb = false;
    private bool climbVertical = false;
    private bool climbUp = false;
    private bool climbHorizontal = false;
    private bool climbRigth = false;

    private readonly float dashDuration = 0.4f;
    private readonly float dashChargeTime = 0.15f;
    private readonly float dashCooldownTime = 1.5f;
    private bool dash = false;
    private float dashTime = 0f;
    private bool dashCooldown = false;
    private float dashCurrentCooldown = 1.5f;

    private GameObject spawnPoint;
    private int lives = 3;
    private bool immunity = false;

    private LifesManager lifesManager;
    private AvisoEnemigosManager avisoEnemigosManager;

    //public Action OnKilled;
    //public Action OnReachedEndOfLevel;


    public void Hitted()
    {
        if (!AdaptacionesManager.VidasYcheckpoints)
            Respawn();
        else
        {
            SetLifesManager();
            if (lives <= 0)
            {
                Respawn();
                lives = 3;
                lifesManager.RefillLifes();
            }
            else
            {
                lives--;
                immunity = true;
                lifesManager.RemoveLife();
                Invoke(nameof(SetNotInmunity), 1);
            }
        }
    }

    private void Respawn()
    {
        transform.position = spawnPoint.transform.position;
        SoundManager.PlaySound(SoundsEnum.Spawn);
    }

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
        SetLifesManager();
        avisoEnemigosManager = GameObject.FindGameObjectWithTag("AvisoEnemigosManager").GetComponent<AvisoEnemigosManager>();
    }

    private void SetLifesManager()
    {
        if(lifesManager == null)
        {
            var lifesManagerGameObject = GameObject.FindGameObjectWithTag("LifesManager");
            lifesManager = lifesManagerGameObject != null ? lifesManagerGameObject.GetComponent<LifesManager>() : null;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (dashCooldown)
            RechargeDash();

        if (rb.velocity.x < 0.15f && rb.velocity.x > -0.15f)
            anim.SetBool("Correr", false);
        else
            anim.SetBool("Correr", true);

        if (dash)
            ExecuteDash();
        else
        {
            if (IsFalling())
            {
                anim.SetBool("Caer", true);
                anim.SetBool("Saltar", false);
            }
            else
            {
                if (anim.GetBool("Caer"))
                    SoundManager.PlaySound(SoundsEnum.Fall);
                anim.SetBool("Caer", false);
            }

            if (!dashCooldown)
                if (Input.GetKey(KeyCode.Space))
                    ChargeDahs();
            if (canClimb)
                Climb();
            else
                CheckMovement();
        }
    }

    private void RechargeDash()
    {
        dashCurrentCooldown -= Time.deltaTime;
        if (dashCurrentCooldown <= 0)
        {
            dashCooldown = false;
            dashCurrentCooldown = dashCooldownTime;
        }
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            MoveBackward();

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            MoveForward();

        if (IsGrounded())
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                Jump();
        }
    }

    private void Climb()
    {
        climbVertical = climbHorizontal = false;

        climbVertical = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        if (climbVertical)
            climbUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);

        climbHorizontal = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        if (climbHorizontal)
            climbRigth = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
    }

    private void FixedUpdate()
    {
        if (dash)
        {
            if (dashTime > dashChargeTime)
                if (loockAtRigth)
                    rb.velocity = dashSpeed * Time.fixedDeltaTime * rb.transform.right;
                else
                    rb.velocity = -1 * dashSpeed * Time.fixedDeltaTime * rb.transform.right;
        }
        if (climbVertical)
            ClimbVertical(climbUp);
        if (climbHorizontal)
            ClimbHorizontal(climbRigth);
    }

    private void ClimbHorizontal(bool right)
    {
        if (right)
            rb.transform.position = new Vector3(rb.transform.position.x + Time.fixedDeltaTime, rb.transform.position.y, rb.transform.position.z);
        else
            rb.transform.position = new Vector3(rb.transform.position.x - Time.fixedDeltaTime, rb.transform.position.y, rb.transform.position.z);
    }

    private void ClimbVertical(bool up)
    {
        if (up)
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + Time.fixedDeltaTime * 3, rb.transform.position.z);
        else
            rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - Time.fixedDeltaTime * 3, rb.transform.position.z);
    }

    private void ChargeDahs()
    {
        anim.SetBool("Cargar", true);
        dash = true;
        //rb.velocity = new Vector2(0, 0);
        SoundManager.PlaySound(SoundsEnum.Dash);
    }

    private void ExecuteDash()
    {
        if (dashTime > dashDuration)
        {

            dash = false;
            dashTime = 0;
            anim.SetBool("Cargar", false);
            dashCooldown = true;
            if (loockAtRigth)
                rb.velocity = new Vector2(maxSpeed, 0);
            else
                rb.velocity = new Vector2(-maxSpeed, 0);
        }
        else
        {
            dashTime += Time.deltaTime;
        }
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
        SoundManager.PlaySound(SoundsEnum.Jump);
    }

    private bool IsFalling()
    {
        return rb.velocity.y < -0.01;
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

    private void SetNotInmunity()
    {
        immunity = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escaleras"))
        {
            canClimb = true;
            rb.velocity = rb.velocity = new Vector2(0, 0); ;
            rb.gravityScale = 0;
            anim.SetBool("Escalar", true);
        }

        if (collision.gameObject.CompareTag("Enemigo") && !immunity)
            anim.SetTrigger("Herido");

        if (collision.gameObject.CompareTag("WeakPoint"))
            collision.gameObject.GetComponentInParent<Animator>().SetBool("Hit", true);

        if (collision.gameObject.CompareTag("DashWeakPoint"))
            if (dash)
                collision.gameObject.GetComponentInParent<Animator>().SetBool("Hit", true);
            else
                anim.SetBool("Herido", true);

        if (collision.gameObject.CompareTag("Finish"))
            rb.velocity = new Vector2(0, rb.velocity.y);

        if (collision.gameObject.CompareTag("SpawnPoint"))
            spawnPoint = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Escaleras"))
        {
            canClimb = false;
            climbVertical = climbHorizontal = false;
            rb.gravityScale = 1;
            anim.SetBool("Escalar", false);
        }

    }
}
