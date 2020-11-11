using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int roomCount;
    public int pRoomCount;
    public RoomSpawner[] activeSpawners;
    public RoomSpawner[] activeSpawners2;
    public bool levelComplete = true;
    public bool levelWorks;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkActiveSpawners()
    {
        activeSpawners = FindObjectsOfType<RoomSpawner>();
        Debug.Log("filling array");
        foreach (RoomSpawner spawner in activeSpawners)
        {
            if (!spawner.spawned)
            {
                levelComplete = false;
            }
        }
        
        Debug.Log("checked array");
        if (levelComplete && pRoomCount == 3)
        {
            levelWorks = true;
            Debug.Log("PERFECT");
        }
        else if (levelComplete && pRoomCount < 3)
        {
            activeSpawners2 = FindObjectsOfType<RoomSpawner>();
            Debug.Log("double checking");
            if (activeSpawners[0] != activeSpawners2[0])
            {
                Debug.Log("Missing some obejects");
            }
            else
            {
                //restart
                Debug.Log("RESTART");
            }
            
        }
        else if(!levelComplete)
        {
            levelComplete = true;
            Debug.Log("RESET");
        }
        else
        {
            Debug.Log("DUNNO LOLOL");
        }
    }
}
