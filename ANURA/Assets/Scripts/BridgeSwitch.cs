using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    public GameObject[] gates;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        Debug.Log("Switch switched");
        foreach (GameObject gate in gates)
        {
            if(gate.GetComponent<Drawbridge>().isclosed == true)
            {
                gate.GetComponent<Drawbridge>().Open();
            }else
            {
                gate.GetComponent<Drawbridge>().Close();
            }
        }
    }
}
