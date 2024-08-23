using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI textUGUI;
    public TextMeshProUGUI ShowTextUGUI;
    public Camera cmr;
    [TextArea]
    public string showText;
    public string sceneNametoLoad;
    public int progress = 0;
    private TypingEffect typingEffect;

    private void Start()
    {
        typingEffect = GetComponent<TypingEffect>();
        InputSystem.Instance.action.Gameplay.Any.performed += context =>
        {
            if ((progress == 0))
            {
                StartCoroutine(ScaleIn());
                textUGUI.gameObject.SetActive(false);
            }
            else if (progress == 1)
            {
                SceneManager.LoadScene(sceneNametoLoad);
                progress = -1;
            }
        };
    }

    IEnumerator ScaleIn()
    {
        while (cmr.orthographicSize > 0.5)
        {
            cmr.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.02f);
        }
        typingEffect.StartTyping(ShowTextUGUI, showText);
        yield return new WaitForSeconds(7f);
        progress = 1;
        textUGUI.gameObject.SetActive(true);
        yield return null;
    }

}
