using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CarModel : Singleton<CarModel>
{
    Animator animator;
    public Light2D BackLight;
    public Light2D FrontLight;
    public float backLightIntensity;
    public float frontLightIntensity;

    public bool apple = false;
    public GameObject objApple;

    public AudioSource BGM;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        objApple.SetActive(false);
    }

    private void Update()
    {
        LightUpdate();
        ModelUpdate();
        if (Movement.Instance.engineOn)
        {
            BGM.Play(); //
        }
    }

    private void ModelUpdate()
    {
        if(apple)
        {
            objApple.SetActive(true);
        }
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
