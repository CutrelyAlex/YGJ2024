using UnityEngine;

public class CountAddTrigger : MonoBehaviour
{
    public string setText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GuideSystem.Instance.guideText = setText;
        this.gameObject.SetActive(false);   
    }
}
