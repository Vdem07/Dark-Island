using UnityEngine;

public class DayCycleManager : MonoBehaviour
{
    [Range(0, 1)]
    public float TimeOfDay;
    public float DayDuration;

    public AnimationCurve SunCurve;
    public AnimationCurve MoonCurve;
    public AnimationCurve SkyboxCurve;
    public AnimationCurve StarsCurve;

    public Material DaySkybox;
    public Material NightSkybox;

    public ParticleSystem Stars;

    public Light Sun;
    public Light Moon;
    [SerializeField] private float StarsIntensityMultiplier;


    public float sunIntensity;
    public float moonIntensity;

    private void Start()
    {
        sunIntensity = Sun.intensity;
        moonIntensity = Moon.intensity;
    }

    private void FixedUpdate()
    {
        TimeOfDay += Time.deltaTime / DayDuration;
        if (TimeOfDay >= 1) { TimeOfDay -= 1;
            Stars.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear); 
            Stars.Play();
            
        }       

        // Настройки освещения (skybox и основное солнце)
        RenderSettings.skybox.Lerp(DaySkybox, NightSkybox, SkyboxCurve.Evaluate(TimeOfDay));
        RenderSettings.sun = SkyboxCurve.Evaluate(TimeOfDay) > 0.0001f ? Moon : Sun;
        DynamicGI.UpdateEnvironment();

        // Прозрачность звёзд
        var mainModule = Stars.main;
        mainModule.duration = DayDuration / 2;
        var startColor = mainModule.startColor.color;
        startColor.a = 1 - StarsCurve.Evaluate(TimeOfDay) * StarsIntensityMultiplier;
        mainModule.startColor = startColor;

        // Поворот луны и солнца
        Sun.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f + 180f, 180, 0);
        Moon.transform.localRotation = Quaternion.Euler(TimeOfDay * 360f, 180, 0);

        // Интенсивность свечения луны и солнца
        Sun.intensity = sunIntensity * SunCurve.Evaluate(TimeOfDay);
        Moon.intensity = moonIntensity * MoonCurve.Evaluate(TimeOfDay);
    }
}

