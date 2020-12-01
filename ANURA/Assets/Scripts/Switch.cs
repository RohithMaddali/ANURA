using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public GameObject[] gates;
    public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void Activate()
    {
        Debug.Log("Switch switched");
        foreach (GameObject gate in gates)
        {
            if(gate.GetComponent<Gate>().isclosed == true)
            {
                anim.SetTrigger("on");
                gate.GetComponent<Gate>().Open();
            }
            else
            {
                anim.SetTrigger("off");
                gate.GetComponent<Gate>().Close();
            }
        }
    }
}
