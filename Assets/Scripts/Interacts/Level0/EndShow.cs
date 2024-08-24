using TMPro;
using UnityEngine;

public class EndShow : MonoBehaviour
{
    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Movement.Instance.engineOn = false;
        GuideSystem.Instance.guideText = " ";
    }
}
