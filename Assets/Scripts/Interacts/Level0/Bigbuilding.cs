using UnityEngine;

public class Bigbuilding : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "奇怪的高塔，会有什么吗?还是快点回家吧";
    }
}
