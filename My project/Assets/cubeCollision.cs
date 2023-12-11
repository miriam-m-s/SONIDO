using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public FMODUnity.StudioEventEmitter barEmmitter;
    private FMOD.Studio.EventInstance barInstance;
 
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

        _2DEventDescription.getParameterDescriptionByName("Material_cube", out _2DParameterDesc);

        _2D_ID = _2DParameterDesc.id;
    }


   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Debug.Log("Aguaa");
            barInstance.setParameterByIDWithLabel(_2D_ID, "water");
            barInstance.start();
        }
    }

    
}
