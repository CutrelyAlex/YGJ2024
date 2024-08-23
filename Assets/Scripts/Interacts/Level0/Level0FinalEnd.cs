using System.Collections;
using UnityEngine;

public class Level0FinalEnd : MonoBehaviour
{
    public GameObject ºÚÄ»;
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
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}
