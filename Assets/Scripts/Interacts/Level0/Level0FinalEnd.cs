using System.Collections;
using UnityEngine;

public class Level0FinalEnd : MonoBehaviour
{
    public GameObject ºÚÄ»;
    public AudioSource BGM;
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
        ºÚÄ».SetActive (true);
        while(BGM.volume > 0)
        {
            BGM.volume -= 0.03f;
            yield return new WaitForSeconds(0.2f);
        }
        yield return null;
    }
}
