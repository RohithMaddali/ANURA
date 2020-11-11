using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int roomCount;
    public int pRoomCount;
    public SpaceCheck[] activeRooms;
    public bool levelComplete = true;
    public bool levelWorks;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("checkActiveSpawners", 3.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkActiveSpawners()
    {
        /*activeSpawners = FindObjectsOfType<RoomSpawner>();
        Debug.Log("filling array");
        foreach (RoomSpawner spawner in activeSpawners)
        {
            if (!spawner.spawned)
            {
                levelComplete = false;
            }
        }
        
        Debug.Log("checked array");*/
        if (/*levelComplete &&*/ pRoomCount == 3)
        {
            levelWorks = true;
            Debug.Log("PERFECT");
            //fill rooms
            activeRooms = FindObjectsOfType<SpaceCheck>();
            foreach(SpaceCheck tempRoom in activeRooms)
            {
                Instantiate(tempRoom.myRoom, tempRoom.transform.position, tempRoom.transform.rotation);
                Destroy(tempRoom.gameObject);
            }
        }
        else if (/*levelComplete &&*/ pRoomCount < 3)
        {
            //restart
            Debug.Log("RESTART");
            //reload level?
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        /*else if(!levelComplete)
        {
            levelComplete = true;
            Debug.Log("RESET");
        }
        else
        {
            Debug.Log("DUNNO LOLOL");
        }*/
    }
    
}
