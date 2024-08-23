using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    public void StartTyping(TextMeshProUGUI textComponent, string text)
    {
        // 停止当前的打字机效果并启动新的
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(textComponent, text));
    }

    private IEnumerator TypeText(TextMeshProUGUI textComponent, string text)
    {
        textComponent.text = ""; // 清空当前文本
        foreach (char letter in text.ToCharArray())
        {
            textComponent.text += letter; // 逐字添加
            yield return new WaitForSeconds(typingSpeed); // 等待一段时间再添加下一个字符
        }

        typingCoroutine = null; // 完成后将协程引用设置为空
    }
}
