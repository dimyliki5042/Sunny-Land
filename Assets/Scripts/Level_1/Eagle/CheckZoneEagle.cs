using UnityEngine;

public class CheckZoneEagle : MonoBehaviour
{
    Eagle eagle;
    private void Awake()
    {
        eagle = transform.parent.GetComponent<Eagle>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
        {
            eagle.detected = true;
            transform.gameObject.SetActive(false);
        }
    }
}
