using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class ApplyLowPass : MonoBehaviour
{

    private FMOD.Studio.EventInstance instance;

    [FMODUnity.EventRef]
    public string fmodEvent;

    [SerializeField]
    private float obstruccionValue;

    // Start is called before the first frame update
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance(fmodEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        instance.setParameterByName("Obstruccion", obstruccionValue);
    }
}
