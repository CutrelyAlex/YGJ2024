using UnityEditor;
using UnityEngine;

public class Level0Guider : MonoBehaviour
{
    private int guideProgress = 0;
    private void Start()
    {
        GuideSystem.Instance.guideText = "按G启动引擎";
    }

    private void Update()
    {
        if (guideProgress == 0 && Movement.Instance.engineOn)
        {
            guideProgress++;
            GuideSystem.Instance.guideText = "按D向右发车";
        }
        else if(guideProgress == 1 && Movement.Instance.braking)
        {
            guideProgress++;
            GuideSystem.Instance.guideText = "用鼠标和物体进行交互";
        }
    }

}
