using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] gates;
    public void Activate()
    {
        Debug.Log("Switch switched");
        foreach (GameObject gate in gates)
        {
            if(gate.GetComponent<Gate>().isclosed == true)
            {
        
                gate.GetComponent<Gate>().Open();
            }
            else
            {
                
                gate.GetComponent<Gate>().Close();
            }
        }
    }
}
