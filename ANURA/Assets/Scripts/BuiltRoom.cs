using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuiltRoom : MonoBehaviour
{

    public GameObject[] toads;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateAI()
    {
        foreach(GameObject toad in toads)
        {
            toad.SetActive(true);
        }
    }
}
