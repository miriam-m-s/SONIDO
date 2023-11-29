using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkingAudio : MonoBehaviour
{
   [SerializeField]
    FMODUnity.EventReference stepEventRef;



    private FMOD.Studio.EventInstance stepInstance;


    private FMOD.Studio.PARAMETER_ID speed_id;

    FirstPersonController movementController;


    bool onSand = true;
    bool playing;
    private void Start()
    {
        playing = false;


        movementController = GetComponent<FirstPersonController>();

        stepInstance = RuntimeManager.CreateInstance(stepEventRef);

        //stepInstance = stepEmitter.EventInstance;
        FMOD.Studio.EventDescription stepEventDescription;
        stepInstance.getDescription(out stepEventDescription);


        
        
        FMOD.Studio.PARAMETER_DESCRIPTION speedDescript;
        stepEventDescription.getParameterDescriptionByName("speed", out speedDescript);
        speed_id = speedDescript.id;

        //stepInstance.start();
    
        stepInstance.start();

    }
    // Update is called once per frame
    void Update()
      
    {
      
        stepInstance.setParameterByID(speed_id, movementController.getVel()*15);
        ////if (Input.GetKey(KeyCode.Space))
        ////{
        ////    FMODUnity.RuntimeManager.PlayOneShot("event:/hipo");

        ////}

        //if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && movementController.isGrounded){
        //    if (!playing)
        //    {
        //        stepInstance.start();
        //        playing = true;
        //    }
        //}
        //else{
        //    if (playing){
        //        stepInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        //        playing = false;
        //    }
        //}


        ////if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        ////{
        ////    stepEmitter.EventInstance.setParameterByName("Moving", 0);
        ////}

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //{
        //    stepInstance.setParameterByID(speed_id, 75.0f);
        //}
        //if (Input.GetKeyUp(KeyCode.LeftShift)){
        //    stepInstance.setParameterByID(speed_id, 57.9f);
        //}
    }

    public void setSand()
    {
        onSand = !onSand;

        //if (onSand) stepEmitter.EventInstance.setParameterByName("Sand", 1);
        //else stepEmitter.EventInstance.setParameterByName("Sand", 0);
    }

    private void OnDestroy()
    {
        stepInstance.release();
    }

    private void OnTriggerEnter(Collider other){
        //if(other.gameObject.tag == "Port"){
        //    float _terrain;
        //    stepInstance.getParameterByID(Terrain_ID, out _terrain);

        //    if((Terrain)((int)_terrain) == Terrain.Sand)
        //    {
        //        //Debug.Log("Puerto");
        //        stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Wood);
        //    }

        //    if ((Terrain)((int)_terrain) == Terrain.Wood)
        //        stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Sand);
        //}

        //if (other.gameObject.tag == "Water")
        //{
        //    float _terrain;
        //    stepInstance.getParameterByID(Terrain_ID, out _terrain);

        //    if ((Terrain)((int)_terrain) == Terrain.Sand)
        //        stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Water);

        //    if ((Terrain)((int)_terrain) == Terrain.Water)
        //        stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Sand);
        //}
    }
}