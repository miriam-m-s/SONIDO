using FMODUnity;
using UnityEngine;
using UnityEngine.Playables;

public class barSonido : MonoBehaviour
{

    FMODUnity.StudioEventEmitter barEmmitter;
    private FMOD.Studio.EventInstance barInstance;

    // Referencia al transform del personaje (asegúrate de asignarla desde el Inspector)
    public Transform personaje;
    public float offset = 5.0f;
    [SerializeField]

    private FMOD.Studio.PARAMETER_ID multiban_id;
    float multi = 0f;
    private FMOD.Studio.PARAMETER_ID _2D_ID;

    private void Start()
    {
        barEmmitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();

        barInstance = barEmmitter.EventInstance;

        FMOD.Studio.EventDescription _2DEventDescription;
        barInstance.getDescription(out _2DEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION _2DParameterDesc;

        _2DEventDescription.getParameterDescriptionByName("MariCarmen", out _2DParameterDesc);

        _2D_ID = _2DParameterDesc.id;
    }


    void changeMultiBand()
    {
       
        barInstance.setParameterByID(_2D_ID, 0.0f);

        float distancia = Vector3.Distance(transform.position, personaje.position);


        if (distancia < offset)
        {
            multi = Mathf.Clamp(1 - (distancia/offset), 0.0f, 1.0f);

            Debug.Log("Yo queria hacelo asi u poco smoth: " + multi);
            //    //barInstance.setParameterByID(multiban_id, multi);
            barInstance.setParameterByID(_2D_ID, multi);
      
        }
        

        



    }

    // Update is called once per frame
    void Update()
    {
        changeMultiBand();
    }
}


