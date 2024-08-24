using System.Collections;
using UnityEngine;

public class endGame : MonoBehaviour
{
    bool isCheck =  false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isCheck = true;
    }

    private void Update()
    {
        if(isCheck)
        {
            if(Input.GetKeyDown(KeyCode.G))
            {
                Application.Quit(); 
            }
        }
    }

}
