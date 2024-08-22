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
    public float typingSpeed = 0.05f; // 控制打字机效果的速度
    private int GuideLast = -1;
    public bool Level0;

    private Coroutine typingCoroutine;

    private void Update()
    {
        GuideCount = Mathf.Min(guideTextsList.Count - 1, GuideCount);

        // 当 GuideCount 改变时，开始显示新文本
        if (typingCoroutine == null && GuideLast != GuideCount)
        {
            GuideLast = GuideCount;
            // 停止当前的打字机效果并启动新的
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
        guidTextUGUI.text = ""; // 清空当前文本
        foreach (char letter in text.ToCharArray())
        {
            guidTextUGUI.text += letter; // 逐字添加
            yield return new WaitForSeconds(typingSpeed); // 等待一段时间再添加下一个字符
        }

        typingCoroutine = null; // 完成后将协程引用设置为空
    }
}