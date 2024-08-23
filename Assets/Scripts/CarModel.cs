using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CarModel : MonoBehaviour
{
    public Light2D BackLight;
    public Light2D FrontLight;
    public float backLightIntensity;
    public float frontLightIntensity;
    private void Awake()
    {
    }
    private void Update()
    {
        LightUpdate();
    }

    void LightUpdate()
    {
        if (Movement.Instance.braking && Movement.Instance.engineOn)
        {
            BackLight.intensity = backLightIntensity;
        }
        else
        {
            BackLight.intensity = 0.1f;
        }

        if (Movement.Instance.engineOn)
        {
            FrontLight.intensity = frontLightIntensity;
        }
        else
        {
            FrontLight.intensity = 0.1f;
        }
    }
}
