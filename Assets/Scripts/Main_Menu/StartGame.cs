using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButton("Submit"))
            SceneManager.LoadScene(1);

        if (Input.GetButton("Cancel"))
            Application.Quit();
    }
}
