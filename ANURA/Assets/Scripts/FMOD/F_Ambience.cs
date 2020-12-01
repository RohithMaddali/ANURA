using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_Ambience : MonoBehaviour
{
    public static EventInstance amb;
    private EventDescription ambDescription;
    private PARAMETER_DESCRIPTION[] pDs = new PARAMETER_DESCRIPTION[4];
    public static PARAMETER_ID[] parameterIds = new PARAMETER_ID[4];

    void Start()
    {
        GetParameterIds();
        amb = RuntimeManager.CreateInstance("event:/Ambience/Amb_UnderGround");
        amb.start();
        amb.release();
    }
    void GetParameterIds()
    {
        ambDescription = RuntimeManager.GetEventDescription("event:/Ambience/Amb_UnderGround");
        ambDescription.getParameterDescriptionByName("RunningWater", out pDs[0]);
        ambDescription.getParameterDescriptionByName("Wind", out pDs[1]);
        ambDescription.getParameterDescriptionByName("Stingers", out pDs[2]);
        ambDescription.getParameterDescriptionByName("WaterDrops", out pDs[3]);
        
        for (int i = 0; i < pDs.Length; i++)
        {
            parameterIds[i] = pDs[i].id;
        }
    }

    private void OnDestroy()
    {
        amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
