using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Possum : Entity
{
    bool isLeft;
    float speed = 5f;
    private void Awake()
    {
        isLeft = true;
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
        Vector3 possumPos = transform.position;
        transform.position = Vector3.MoveTowards(possumPos, possumPos + (transform.right * 2f), speed * Time.deltaTime);
    }
    void CheckWall()
    {
        Collider2D[] collidersWall = Physics2D.OverlapCircleAll(transform.position + (transform.right * 0.9f) + (transform.up * 0.8f), 0.1f);
        foreach (Collider2D i in collidersWall)
        {
            if (i.gameObject == Player.Instance.gameObject)
                Player.Instance.Die();
        }
        if (collidersWall.Length > 1)
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
            Player.Instance.Die();
    }
}
