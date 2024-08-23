using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TypingEffect))]
public class GuideSystem : Singleton<GuideSystem>
{
    public string guideText;
    private string lastGuideText;

    public TextMeshProUGUI guidTextUGUI;
    private TypingEffect typingEffect;

    private void Start()
    {
        typingEffect = GetComponent<TypingEffect>();
        if (typingEffect == null)
        {
            Debug.LogError("TypingEffect component is missing from the GuideSystem object.");
        }
    }

    public void SetGuideText(string text)
    {
        guideText = text;
    }

    private void Update()
    {
        if (lastGuideText != guideText)
        {
            lastGuideText = guideText;
            typingEffect.StartTyping(guidTextUGUI, guideText);
        }
    }
}
