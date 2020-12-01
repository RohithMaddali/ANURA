using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    public GameObject[] gates;
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponentInChildren<Animator>();
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
                //anim.SetTrigger("on");
                gate.GetComponent<Drawbridge>().Open();
            }else
            {
                //anim.SetTrigger("off");
                gate.GetComponent<Drawbridge>().Close();
            }
        }
    }
}
