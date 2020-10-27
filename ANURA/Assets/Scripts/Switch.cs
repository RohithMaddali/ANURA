using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
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
            if(gate.GetComponent<Gate>().isclosed == true)
            {
                gate.GetComponent<Gate>().Open();
            }else
            {
                gate.GetComponent<Gate>().Close();
            }
        }
    }
}
