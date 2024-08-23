using System.Collections;
using UnityEngine;

public class Level0FinalEnd : MonoBehaviour
{
     
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Final());
    }

    IEnumerator Final()
    {
        
        yield return null;
    }
}
