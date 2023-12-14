using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class Breath : MonoBehaviour
{

    [SerializeField]
    FMODUnity.EventReference breathEventRef;
    private FMOD.Studio.EventInstance BreathInstance;

    void Start()
    {

        BreathInstance = RuntimeManager.CreateInstance(breathEventRef);
        BreathInstance.start();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            BreathInstance.setParameterByName("Respiracion", 2);
            BreathInstance.setParameterByName("SnowIntensity", Random.Range(0.7f, 1.0f));
        }

        if (other.gameObject.tag == "Torch")
        {
            BreathInstance.setParameterByName("Respiracion", 1);
            BreathInstance.setParameterByName("SnowIntensity", 0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        BreathInstance.setParameterByName("Respiracion", 0);
        BreathInstance.setParameterByName("SnowIntensity", Random.Range(0.4f, 0.7f));
    }
}
