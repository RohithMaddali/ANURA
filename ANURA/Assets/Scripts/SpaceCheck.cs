using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCheck : MonoBehaviour
{
    public bool fits;
    public bool sits;
    public RoomSpawner mySpawner;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        fits = true;
        Invoke("IfFitsSits", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IfFitsSits()
    {
        Debug.Log("check if fits");
        if (fits)
        {
            sits = true;
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Interior") && sits)
        {
            Debug.Log("no space");
            other.GetComponentInParent<SpaceCheck>().fits = false;
            Debug.Log(other.gameObject + " in " + gameObject);
        }
        if (other.CompareTag("Interior") && !sits)
        {
            fits = false;
            Debug.Log(other.gameObject + " in " + gameObject);
        }
        if (other.CompareTag("TempRoom") && sits)
        {
            other.GetComponent<SpaceCheck>().fits = false;
            Debug.Log(other.gameObject + " in " + gameObject);
        }
        if (other.CompareTag("TempRoom") && !sits)
        {
            fits = false;
            Debug.Log(other.gameObject +  " in " + gameObject);
        }
        /*if (other.CompareTag("RoomSpawn") && mySpawner.spawned)
        {
            other.gameObject.SetActive(false);
            Debug.Log(other.gameObject + " in " + gameObject);

        }*/
        /*else
        {
            fits = true;
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(true);
            }
        }*/
        /*if(other.CompareTag("RoomSpawn"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == true)
            {
                Debug.Log("it fits");
                fits = true;
                foreach (GameObject spawner in spawners)
                {
                    spawner.SetActive(true);
                }
            }
            
        }
        if (other.CompareTag("StartRoomSpawn"))
        {
            if (other.GetComponent<FirstRoom>().spawned == true)
            {
                Debug.Log("it fits");
                fits = true;
                foreach (GameObject spawner in spawners)
                {
                    spawner.SetActive(true);
                }
            }

        }*/
    }
}
