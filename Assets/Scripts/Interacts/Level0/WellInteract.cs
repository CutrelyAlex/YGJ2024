using UnityEngine;

public class WellInteract : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "这是人在自然中的共舞节奏。";
    }
}
