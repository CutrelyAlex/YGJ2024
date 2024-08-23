using TMPro;
using UnityEngine;

public class EndShow : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start()
    {
        text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        text.gameObject.SetActive(true);
        Movement.Instance.engineOn = false;
        GuideSystem.Instance.guideText = " ";
    }
}
