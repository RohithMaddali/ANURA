using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrigger : MonoBehaviour
{
    public GameObject toad;
    public GameObject aiTriggersphere;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Toad"))
            {
                toad.GetComponent<FOVDetection>().enabled = true;
                toad.GetComponent<Patroller>().enabled = true;
                Debug.Log("Enable AI");  
            }
            
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Toad"))
            {
                toad.GetComponent<FOVDetection>().enabled = false;
                toad.GetComponent<Patroller>().enabled = false;
                Debug.Log("Disable AI");
            }
        }
    }
/*
    IEnumerator aiHandler()
    {
        void OnTriggerEnter(Collider other)
        {

            if (other.CompareTag("Toad"))
            {
              toad.GetComponent<FOVDetection>().enabled = true;
                          toad.GetComponent<Patroller>().enabled = true;
                          Debug.Log("Enable AI");  
            }
            
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Toad"))
            {
                toad.GetComponent<FOVDetection>().enabled = false;
                toad.GetComponent<Patroller>().enabled = false;
                Debug.Log("Disable AI");
            }
        }

        yield return new WaitForSeconds(0.1f);
    }
    */
}