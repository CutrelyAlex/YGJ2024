using UnityEngine;

public class AppleInteract : MonoBehaviour, IInteract
{
    public void Interact()
    {
        GuideSystem.Instance.guideText = "��ƻ����װ�����ϰ�";
        CarModel.Instance.apple = true;
        gameObject.SetActive(false);
    }
}
