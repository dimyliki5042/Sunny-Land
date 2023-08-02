using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Entity
{
    bool isLeft;
    float speed = 5f;
    public bool detected;
    private void Awake()
    {
        isLeft = false;
        detected = false;
    }
    private void FixedUpdate()
    {
        CheckWall();
    }
    private void Update()
    {
        Move();
    }
    void Move()
    {
        Vector3 eaglePos = transform.position;
        if(!detected)
            transform.position = Vector3.MoveTowards(eaglePos, eaglePos + (transform.right * 2f), speed * Time.deltaTime);
        else
        {
            Vector3 playerPos = Player.Instance.transform.position;
            transform.position = Vector3.MoveTowards(eaglePos, playerPos, speed * Time.deltaTime);
        }
    }
    void CheckWall()
    {
        Collider2D[] collidersWall = Physics2D.OverlapCircleAll(transform.position + (-transform.up * 0.5f) + (transform.right * 1f), 0.1f);
        foreach(Collider2D i in collidersWall)
        {
            if(i.gameObject == Player.Instance.gameObject)
                Player.Instance.Die();
        }
        if (collidersWall.Length > 2)
        {
            if (isLeft)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
            }
            else
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
            }
            isLeft = !isLeft;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (-transform.up * 0.5f) + (transform.right * 1f), 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
            Player.Instance.Die();
    }
}
