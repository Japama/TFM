using UnityEngine;

public class TurtleManager : MonoBehaviour
{
    public bool spikesOut = false;
    public float speed;
    public int maxSpeed;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private WarningZoneController warningZoneController;
    private Animator animator;
    private bool goLeft;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        warningZoneController = GetComponentInParent<WarningZoneController>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        //InvokeRepeating(nameof(SwitchSpikes), 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (!spikesOut)
            Move();
        else
            rb.velocity = Vector2.zero;
    }

    void SetSpikes(bool spikes)
    {
        if (spikes)
            animator.SetTrigger("SpikesOut");
        else
            animator.SetTrigger("SpikesIn");
    }

    private void Move()
    {
        var right = transform.right;
        if (rb.velocity.x > -maxSpeed && rb.velocity.x < maxSpeed)
            rb.velocity += speed * Time.deltaTime * new Vector2(right.x * speed, right.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("TurnPoint"))
        {
            int direction = goLeft ? 1 : -1;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + 0.2f * direction, gameObject.transform.position.y, gameObject.transform.position.z);
            rb.velocity = Vector2.zero;
            transform.eulerAngles = transform.eulerAngles + 180f * Vector3.up;
            SetSpikes(spikes: true);
            goLeft = !goLeft;
            Invoke(nameof(RemoveSpikes), Random.Range(3f, 6f));
        }
    }

    private void RemoveSpikes()
    {
        SetSpikes(false);
        spikesOut = false;
    }

    public void Hitted()
    {
        SoundManager.PlaySound(SoundsEnum.EmemyHitted);
        animator.SetTrigger("Hitted");
        transform.tag = "EnemyDeath";
    }

    private void OnDestroy()
    {
        warningZoneController.DeleteEnemy(gameObject);
    }
}
