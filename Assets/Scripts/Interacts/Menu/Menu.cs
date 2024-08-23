using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI textUGUI;
    public Camera cmr;
    private void Start()
    {
        InputSystem.Instance.action.Gameplay.Any.performed += context =>
        {
            StartCoroutine(ScaleIn());
            textUGUI.gameObject.SetActive(false);
        };
    }

    IEnumerator ScaleIn()
    {
        while (cmr.orthographicSize > 0.5)
        {
            cmr.orthographicSize -= 0.1f;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }

}
