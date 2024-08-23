using UnityEditor;
using UnityEngine;

public class Level0Guider : MonoBehaviour
{
    private int guideProgress = 0;
    private void Start()
    {
        GuideSystem.Instance.guideText = "��G��������";
    }

    private void Update()
    {
        if (guideProgress == 0 && Movement.Instance.engineOn)
        {
            guideProgress++;
            GuideSystem.Instance.guideText = "��D���ҷ���";
        }
        else if(guideProgress == 1 && Movement.Instance.braking)
        {
            guideProgress++;
            GuideSystem.Instance.guideText = "������������н���";
        }
    }

}
