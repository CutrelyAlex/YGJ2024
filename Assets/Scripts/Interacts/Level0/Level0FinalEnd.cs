using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level0FinalEnd : MonoBehaviour
{
    private void Start()
    {
        ºÚÄ».SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Final());
    }

    IEnumerator Final()
    {
        SceneManager.LoadScene("Level1");
        yield return null;
    }
}
