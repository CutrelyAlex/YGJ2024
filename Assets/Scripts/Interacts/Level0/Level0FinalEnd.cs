using System.Collections;
using UnityEngine;

public class Level0FinalEnd : MonoBehaviour
{
    public GameObject ��Ļ;
    private void Start()
    {
        ��Ļ.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Final());
    }

    IEnumerator Final()
    {
        ��Ļ.SetActive (true);
        yield return new WaitForSeconds(2f);
        yield return null;
    }
}
