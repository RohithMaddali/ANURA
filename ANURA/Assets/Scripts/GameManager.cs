using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.AI;

public class GameManager : MonoBehaviour
{
    public int roomCount;
    public int pRoomCount;
    public SpaceCheck[] activeRooms;
    public List<GameObject> spawnedRooms = new List<GameObject>();
    public GameObject builtRoom;
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
                builtRoom = Instantiate(tempRoom.myRoom, tempRoom.transform.position, tempRoom.transform.rotation);
                spawnedRooms.Add(builtRoom);
                //add built room to spawned rooms array
                Destroy(tempRoom.gameObject);
            }
            NavMeshBuilder.BuildNavMesh();
            Debug.Log("NAVMESH BUILT");
            //have each room in spawned rooms array activate their AI
            foreach(GameObject room in spawnedRooms)
            {
                room.GetComponent<BuiltRoom>().ActivateAI();
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
