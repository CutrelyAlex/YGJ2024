using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CarModel : MonoBehaviour
{
    public Light2D BackLight;
    public Light2D FrontLight;
    public float backLightIntensity;
    public float frontLightIntensity;
    Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    private void Update()
    {
        LightUpdate();
    }

    void LightUpdate()
    {
        if (movement.braking && movement.engineOn) BackLight.intensity = backLightIntensity;
        else BackLight.intensity = 0.1f;

        if (movement.engineOn) FrontLight.intensity = frontLightIntensity;
        else frontLightIntensity = 0.1f;
    }
}
