using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_KeyPickup : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                
            }
        }
    }
}
