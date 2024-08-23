using System.Collections;
using UnityEngine;

public class InteractThanGuide : MonoBehaviour, IInteract
{
    public string text;
    public bool hasStayTime;
    public float stayTime;
    private bool showing;
    public void Interact()
    {
        if (!showing)
        {
            if (!hasStayTime) stayTime = float.MaxValue;
            StartCoroutine(SetText());
        }

        showing = true;
    }

    IEnumerator SetText()
    {
        GuideSystem.Instance.guideText = text;
        yield return new WaitForSeconds(stayTime);
        if (GuideSystem.Instance.guideText == text)
        {
            GuideSystem.Instance.guideText = " ";
        }
        showing = false;
        yield return null;
    }
}
