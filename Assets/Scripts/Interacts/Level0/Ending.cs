using UnityEngine;

public class Ending : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "该去下一个地方了";
    }
}
