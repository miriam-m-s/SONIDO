using FMODUnity;
using UnityEngine;
using UnityEngine.Playables;

public class barSonido : MonoBehaviour
{
    // Referencia al transform del personaje (asegúrate de asignarla desde el Inspector)
    public Transform personaje;
    public float offset=5.0f;
    [SerializeField]
    FMODUnity.EventReference tempEventRef;
    private FMOD.Studio.EventInstance BarInstance;
    private FMOD.Studio.PARAMETER_ID multiban_id;
    float multi=0f;

    void Start()
    {
      

        FMOD.Studio.EventDescription barEventDescription;
        FMOD.Studio.EventInstance BarInstance = RuntimeManager.CreateInstance(tempEventRef);
        BarInstance.getDescription(out barEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION multiband;
        barEventDescription.getParameterDescriptionByName("multiband", out multiband);
        multiban_id = multiband.id;
        BarInstance.start();
        // No necesitas llamar a BarInstance.start() aquí si estás controlando la reproducción desde el Timeline.
    }

    void Update()
    {
        if (personaje != null)
        {
            float distancia = Vector3.Distance(transform.position, personaje.position);
            BarInstance.setParameterByID(multiban_id, 0);


            if (distancia < offset)
            {
                float smoothstepValue = Mathf.SmoothStep(0f, offset, distancia);
                multi = 1f - smoothstepValue;
                BarInstance.setParameterByID(multiban_id, multi);
            }
        }
        else
        {
            Debug.LogError("La referencia al personaje no está asignada en el Inspector.");
        }
    }
}


