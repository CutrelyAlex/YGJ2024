using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuideSystem : Singleton<GuideSystem>
{
    public Movement cardMovement;
    public int GuideCount = 0;
    public List<string> guideTextsList;
    public TextMeshProUGUI guidTextUGUI;
    public float typingSpeed = 0.05f; // ���ƴ��ֻ�Ч�����ٶ�
    private int GuideLast = -1;
    public bool Level0;

    private Coroutine typingCoroutine;

    private void Update()
    {
        GuideCount = Mathf.Min(guideTextsList.Count - 1, GuideCount);

        // �� GuideCount �ı�ʱ����ʼ��ʾ���ı�
        if (typingCoroutine == null && GuideLast != GuideCount)
        {
            GuideLast = GuideCount;
            // ֹͣ��ǰ�Ĵ��ֻ�Ч���������µ�
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeText(guideTextsList[GuideCount]));
        }

        if(Level0)
        {
            if (GuideCount == 0 && cardMovement.engineOn)
            {
                GuideCount++;
            }
            else if(GuideCount == 2 && cardMovement.stoping)
            {
                GuideCount++;
            }
        }
    }


    private IEnumerator TypeText(string text)
    {
        guidTextUGUI.text = ""; // ��յ�ǰ�ı�
        foreach (char letter in text.ToCharArray())
        {
            guidTextUGUI.text += letter; // �������
            yield return new WaitForSeconds(typingSpeed); // �ȴ�һ��ʱ���������һ���ַ�
        }

        typingCoroutine = null; // ��ɺ�Э����������Ϊ��
    }
}