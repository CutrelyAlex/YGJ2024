using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalEnd : MonoBehaviour
{
    public string NextLevel;
    public GameObject ºÚÄ»;
    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Final());
    }

    IEnumerator Final()
    {
        ºÚÄ».gameObject.SetActive(true);
        while(CarModel.Instance.BGM.volume > 0)
        {
            CarModel.Instance.BGM.volume -= 0.1f;
            yield return new WaitForSeconds(0.5f);
        }
        SceneManager.LoadScene(NextLevel);
        yield return null;
    }
}
