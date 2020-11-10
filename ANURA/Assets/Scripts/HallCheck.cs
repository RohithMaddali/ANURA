using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Interior") && !gameObject.GetComponentInParent<SpaceCheck>().sits)
        {
            gameObject.GetComponentInParent<SpaceCheck>().fits = false;
            Debug.Log("HALL CHECK HIT ANOTHER ROOM");
        }
    }
}
