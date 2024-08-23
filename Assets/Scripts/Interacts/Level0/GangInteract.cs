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
        string text = "一个在路边的破缸，还好没在路中央";
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
