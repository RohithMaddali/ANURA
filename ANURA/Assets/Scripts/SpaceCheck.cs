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
        Invoke("IfFitsSits", .5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IfFitsSits()
    {
        if (fits)
        {
            sits = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        if (!other.CompareTag("RoomSpawn") && !sits)
        {
            Debug.Log("no space");
            fits = false;
            Debug.Log(other.gameObject);
        }
        else
        {
            fits = true;
            foreach (GameObject spawner in spawners)
            {
                spawner.SetActive(true);
            }
        }
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
