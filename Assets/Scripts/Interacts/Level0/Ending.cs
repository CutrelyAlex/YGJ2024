using UnityEngine;

public class Ending : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "��ȥ��һ���ط���";
    }
}
