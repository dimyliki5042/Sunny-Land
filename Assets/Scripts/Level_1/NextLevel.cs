using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == Player.Instance.gameObject)
        {
            if(Player.Instance.allResources == 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
