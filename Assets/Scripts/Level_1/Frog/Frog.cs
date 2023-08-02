using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Entity
{
    public bool detected;
    bool isGround;
    Rigidbody2D rbFrog;
    float jumpForce = 10f;
    float speed = 5f;
    private void Awake()
    {
        rbFrog = transform.GetComponent<Rigidbody2D>();
        detected = false;
        isGround = true;
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    private void Update()
    {
        if (detected)
            Move();
    }

    void Move()
    {
        Vector2 frogPos = transform.position;
        Vector2 playerPos = Player.Instance.transform.position;
        if (isGround)
            rbFrog.velocity = transform.up * jumpForce;
        transform.position = Vector2.MoveTowards(frogPos, playerPos, speed * Time.deltaTime);
    }
    void CheckGround()
    {
        Collider2D[] collidersGround = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        if (collidersGround.Length > 1)
            isGround = true;
        else
            isGround = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
            Player.Instance.Die();
    }
}
