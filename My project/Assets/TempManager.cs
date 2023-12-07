using FMODUnity;
using System.Collections;
using UnityEngine;

public class TempManager : MonoBehaviour
{
    public GameObject lowPass;

    public float minLowPassValue;
    public float maxLowPassValue;
    private float lowPassValue;

    public ParticleSystem fog;
    public ParticleSystem snow;
    int maxEmissionFog = 100;
    int maxEmissionSnow = 2880;
    public float intensity = 0.0f;

    [SerializeField]
    FMODUnity.EventReference tempEventRef;
    private FMOD.Studio.EventInstance TempInstance;
    private FMOD.Studio.PARAMETER_ID intensity_id;

    void Start()
    {
        // Asigna las referencias de las partículas correctamente
        //fog = transform.Find("Fog").GetComponent<ParticleSystem>();
        // snow = transform.Find("SnowParticle").GetComponent<ParticleSystem>();

        // Inicia la corutina que manejará el cambio de intensidad cada minuto
        TempInstance = RuntimeManager.CreateInstance(tempEventRef);

        //stepInstance = stepEmitter.EventInstance;
        FMOD.Studio.EventDescription tempEventDescription;
        TempInstance.getDescription(out tempEventDescription);


        FMOD.Studio.PARAMETER_DESCRIPTION speedDescript;
        tempEventDescription.getParameterDescriptionByName("SnowIntensity", out speedDescript);
        intensity_id = speedDescript.id;

        TempInstance.start();
        StartCoroutine(ChangeIntensityRoutine());
    }

    // Corutina para cambiar la intensidad cada minuto
    IEnumerator ChangeIntensityRoutine()
    {
        while (true)
        {
            // Aumenta la intensidad de 0 a 1
            while (intensity < 1.0f)
            {
                intensity += Time.deltaTime / 60.0f; // Aumenta la intensidad cada segundo
                TempInstance.setParameterByID(intensity_id, intensity);
                SetParticleSystemsIntensity();
                yield return null;
            }

            // Establece la intensidad a 1 para asegurarse de que sea exactamente 1
            intensity = 1.0f;
            TempInstance.setParameterByID(intensity_id, intensity);
            SetParticleSystemsIntensity();

            // Espera un minuto
            yield return new WaitForSeconds(5.0f);

            // Disminuye la intensidad de 1 a 0
            while (intensity > 0.0f)
            {
                intensity -= Time.deltaTime / 60.0f; // Disminuye la intensidad cada segundo
                TempInstance.setParameterByID(intensity_id, intensity);
                SetParticleSystemsIntensity();
                yield return null;
            }

            // Establece la intensidad a 0 para asegurarse de que sea exactamente 0
            intensity = 0.0f;
            TempInstance.setParameterByID(intensity_id, intensity);
            SetParticleSystemsIntensity();

            // Espera un minuto
            yield return new WaitForSeconds(5.0f);
        }
    }

    // Actualiza la intensidad de las partículas
    void SetParticleSystemsIntensity()
    {
        var mainModule = fog.main;

        // Obtiene el color actual
        Color colorActual = mainModule.startColor.color;

        // Modifica el canal alfa del color
        colorActual.a = (float)(intensity * 0.5);  // Establece el canal alfa a 0.5 (50% de transparencia)
        mainModule.startColor = colorActual;
        //Debug.Log(colorActual);

        // Asigna el nuevo color al sistema de partículas
        mainModule.startColor = colorActual;

        var snowMain = snow.emission;
        snowMain.rateOverTime = (int)(maxEmissionSnow * intensity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == lowPass.name)
        {
            lowPassValue = Random.Range(minLowPassValue, maxLowPassValue);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == lowPass.name)
        {
            TempInstance.setParameterByName("Obstruccion", lowPassValue);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == lowPass.name)
        {
            TempInstance.setParameterByName("Obstruccion", 0);
        }
    }
}