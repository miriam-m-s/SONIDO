using FMODUnity;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        BarInstance = RuntimeManager.CreateInstance(tempEventRef);

        //stepInstance = stepEmitter.EventInstance;
        FMOD.Studio.EventDescription barEventDescription;
        BarInstance.getDescription(out barEventDescription);


        FMOD.Studio.PARAMETER_DESCRIPTION multiband;
        barEventDescription.getParameterDescriptionByName("multiband", out multiband);
        multiban_id = multiband.id;

        BarInstance.start();


    }

    // Update is called once per frame
    void Update()
    {
        // Verifica que la referencia al personaje no sea nula
  
      
            // Calcula la distancia entre este objeto y el personaje
            float distancia = Vector3.Distance(transform.position, personaje.position);

            // Haz lo que necesites con la distancia (por ejemplo, imprimir en la consola)
            BarInstance.setParameterByID(multiban_id, 0);
            Debug.Log("DISTANCIA "+distancia);
            // Puedes realizar otras acciones basadas en la distancia, por ejemplo, activar un sonido cuando la distancia sea menor que cierto valor
            if (distancia < offset)
            {
                float smoothstepValue = Mathf.SmoothStep(0f, offset, distancia);

               
                multi = 1f - smoothstepValue;
                BarInstance.setParameterByID(multiban_id, multi);

            
            }
       
    }
}
