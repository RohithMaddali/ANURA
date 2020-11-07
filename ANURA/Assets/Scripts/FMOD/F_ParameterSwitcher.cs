using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class F_ParameterSwitcher : MonoBehaviour
{
    [SerializeField]
    private float runningWater;
    [SerializeField]
    private float wind;
    [SerializeField]
    private float stingers;
    [SerializeField]
    private float waterDrops;
    [SerializeField] 
    private bool onExitSetDefault;

    private float [] values = new float[4];
    //[SerializeField]
    //private bool lerpWind;
    //[SerializeField]
    //private float lerpTime
    
    private void Start()
    {
        values[0] = runningWater;
        values[1] = wind;
        values[3] = stingers;
        values[4] = waterDrops;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Switched");
            //if (lerpWind == true)
                //wind = Mathf.Lerp(wind, 1, lerpTime * Time.deltaTime);
                
                F_Ambience.amb.setParametersByIDs(F_Ambience.parameterIds, values, 4, false);
        }
    }
}
