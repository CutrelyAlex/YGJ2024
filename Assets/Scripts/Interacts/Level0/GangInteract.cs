using System.Collections;
using UnityEngine;

public class GangInteract : MonoBehaviour, IInteract
{
    private bool showing;
    public void Interact()
    {
        if (!showing)
        {
            StartCoroutine(SetText());
        }

        showing = true;
    }

   IEnumerator SetText()
    {
        string text = "һ����·�ߵ��Ƹף�����û��·����";
        GuideSystem.Instance.guideText = text;
        yield return new WaitForSeconds(3f) ;
        if (GuideSystem.Instance.guideText == text)
        {
            GuideSystem.Instance.guideText = " ";
        }
        showing = false;
        yield return null;
    }
}
