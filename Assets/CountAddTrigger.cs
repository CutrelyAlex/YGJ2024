using UnityEngine;

public class CountAddTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuideSystem.Instance.GuideCount++;
        this.gameObject.SetActive(false);   
    }
}
