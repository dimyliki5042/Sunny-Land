using UnityEngine;

public class CheckZoneFrog : MonoBehaviour
{
    Frog frog;
    private void Awake()
    {
        frog = transform.parent.GetComponent<Frog>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
        {
            frog.detected = true;
            transform.gameObject.SetActive(false);
        }
    }
}
