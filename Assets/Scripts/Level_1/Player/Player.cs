using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    #region Variables
    Rigidbody2D rbPlayer;
    Animator animPlayer;
    public static Player Instance { get; set; }
    Vector3 dir;
    [SerializeField] float speed = 10f;
    [SerializeField] float jumpForce = 13f;
    [SerializeField] bool isGround;
    [SerializeField] bool isMoving;
    public int diamond;
    public int cherry;
    public int allResources;
    #endregion

    private void Awake()
    {
        isMoving = false;
        Instance = this;
        rbPlayer = transform.GetComponent<Rigidbody2D>();
        animPlayer = transform.GetComponent<Animator>();
        isGround = true;
        cherry = 3;
        diamond = 2;
    }
    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Start()
    {
        allResources = cherry + diamond;
    }
    private void Update()
    {
        if (!isMoving && isGround)
        {
            States = State.Idle;
        }
        if (Input.GetButton("Horizontal"))
        {
            States = State.Walk;
            isMoving = true;
            Move();
        }
        else
            isMoving = false;

        if (Input.GetButton("Jump") && isGround)
        {
            States = State.Jump;
            Jump();
        }
    }
    void Move()
    {
        if (Input.GetKey("left") | Input.GetKey("a"))
        {
            dir = -transform.right * Input.GetAxis("Horizontal");
            transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }
        if (Input.GetKey("right") | Input.GetKey("d"))
        {
            dir = transform.right * Input.GetAxis("Horizontal");
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);
    }

    void Jump()
    {
        rbPlayer.velocity = transform.up * jumpForce;
    }

    void CheckGround()
    {
        Collider2D[] collidersGround = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        if (collidersGround.Length > 1)
            isGround = true;
        else
            isGround = false;
    }
    public void Collection(int type)
    {
        if (type == 1)
        {
            cherry--;
        }
        else
        {
            diamond--;
        }
        allResources = cherry + diamond;
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene(1);
    }
    enum State
    {
        Idle,
        Walk,
        Jump,
        Die
    }
    State States
    {
        get { return (State)animPlayer.GetInteger("States"); }
        set { animPlayer.SetInteger("States", (int)value); }
    }
}
