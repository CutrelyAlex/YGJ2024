using UnityEngine;

public class WellInteract : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "����������Ȼ�еĹ�����ࡣ";
    }
}
