using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject platforms;
    Animator animLever;
    private void Awake()
    {
        animLever = transform.GetComponent<Animator>();
    }
    private void Start()
    {
        States = State.Deactivated;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == Player.Instance.gameObject)
        {
            States = State.Activated;
            platforms.SetActive(true);
        }
    }
    enum State
    {
        Deactivated,
        Activated
    }
    State States
    {
        get { return (State)animLever.GetInteger("States"); }
        set { animLever.SetInteger("States", (int)value); }
    }
}
