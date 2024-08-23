using System.Collections;
using TMPro;
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public float typingSpeed = 0.05f;
    private Coroutine typingCoroutine;

    public void StartTyping(TextMeshProUGUI textComponent, string text)
    {
        // ֹͣ��ǰ�Ĵ��ֻ�Ч���������µ�
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeText(textComponent, text));
    }

    private IEnumerator TypeText(TextMeshProUGUI textComponent, string text)
    {
        textComponent.text = ""; // ��յ�ǰ�ı�
        foreach (char letter in text.ToCharArray())
        {
            textComponent.text += letter; // �������
            yield return new WaitForSeconds(typingSpeed); // �ȴ�һ��ʱ���������һ���ַ�
        }

        typingCoroutine = null; // ��ɺ�Э����������Ϊ��
    }
}
