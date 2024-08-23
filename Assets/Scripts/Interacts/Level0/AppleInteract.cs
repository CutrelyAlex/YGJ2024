using UnityEngine;

public class AppleInteract : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "大苹果，装到车上吧";
        CarModel.Instance.apple = true;
        gameObject.SetActive(false);
    }
}
