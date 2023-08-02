using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    Text cherry;
    Text diamond;

    private void Awake()
    {
        cherry = transform.GetChild(1).transform.GetChild(0).GetComponent<Text>();
        diamond = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
    }
    private void Update()
    {
        cherry.text = Player.Instance.cherry.ToString();
        diamond.text = Player.Instance.diamond.ToString();
    }
}
