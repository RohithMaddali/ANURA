using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceCheck : MonoBehaviour
{
    public bool fits;
    public RoomSpawner mySpawner;
    public GameObject[] spawners;

    // Start is called before the first frame update
    void Start()
    {
        if(mySpawner.openingDir == 1)
        {
            //turn off 2
            foreach(GameObject spawner in spawners)
            {
                if(spawner.GetComponent<RoomSpawner>().openingDir == 2)
                {
                    spawner.SetActive(false);
                }
            }
        }
        if (mySpawner.openingDir == 2)
        {
            //turn off 1
            foreach (GameObject spawner in spawners)
            {
                if (spawner.GetComponent<RoomSpawner>().openingDir == 1)
                {
                    spawner.SetActive(false);
                }
            }
        }
        if (mySpawner.openingDir == 3)
        {
            //turn off 4
            foreach (GameObject spawner in spawners)
            {
                if (spawner.GetComponent<RoomSpawner>().openingDir == 4)
                {
                    spawner.SetActive(false);
                }
            }
        }
        if (mySpawner.openingDir == 4)
        {
            //turn off 3
            foreach (GameObject spawner in spawners)
            {
                if (spawner.GetComponent<RoomSpawner>().openingDir == 3)
                {
                    spawner.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Interior"))
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
