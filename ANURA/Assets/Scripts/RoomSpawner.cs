using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDir;
    //1 need bottom door
    //2 need top door
    //3 need left door
    //4 need right door
    public Transform iRoomPos;
    public Transform hRoomPos;

    private GameObject pRoomTest;
    private GameObject iRoomTest;
    private GameObject hRoomTest;

    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;


    // Start is called before the first frame update
    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDir == 1)
            {
                //spawn bottom door
                rand = Random.Range(0, templates.bottomPRooms.Length);
                pRoomTest = Instantiate(templates.bottomPRooms[rand], transform.position, templates.bottomPRooms[rand].transform.rotation);
                //check that rooms trigger
                if (pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    //if triggered destroy and spawn I room at I room pos
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.bottomIRooms.Length);
                    iRoomTest = Instantiate(templates.bottomIRooms[rand], iRoomPos.transform.position, templates.bottomIRooms[rand].transform.rotation);
                    //check room trigger
                    if (iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        //if triggered destroy and spawn h room at h room pos
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.bottomHRooms.Length);
                        hRoomTest = Instantiate(templates.bottomHRooms[rand], hRoomPos.transform.position, templates.bottomHRooms[rand].transform.rotation);
                        //check room trigger
                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            //if triggered spawn collapsed doorway
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                }
                else if (pRoomTest.GetComponent<SpaceCheck>().fits == true)
                {
                    //replace with actual room
                    Debug.Log("Fill Room");
                }

            }
            else if (openingDir == 2)
            {
                rand = Random.Range(0, templates.topPRooms.Length);
                pRoomTest = Instantiate(templates.topPRooms[rand], transform.position, templates.topPRooms[rand].transform.rotation);
                if (pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.topIRooms.Length);
                    iRoomTest = Instantiate(templates.topIRooms[rand], iRoomPos.transform.position, templates.topIRooms[rand].transform.rotation);

                    if (iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        //if triggered destroy and spawn h room at h room pos
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.topHRooms.Length);
                        hRoomTest = Instantiate(templates.topHRooms[rand], hRoomPos.transform.position, templates.topHRooms[rand].transform.rotation);

                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            //if triggered spawn collapsed doorway
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                    // spawn top door
                }
                else Debug.Log("Fill Room");
            }

            else if (openingDir == 3)
            {
                rand = Random.Range(0, templates.leftPRooms.Length);
                pRoomTest = Instantiate(templates.leftPRooms[rand], transform.position, templates.leftPRooms[rand].transform.rotation);
                if(pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.leftIRooms.Length);
                    iRoomTest = Instantiate(templates.leftIRooms[rand], iRoomPos.transform.position, templates.leftIRooms[rand].transform.rotation);

                    if(iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.leftHRooms.Length);
                        hRoomTest = Instantiate(templates.leftHRooms[rand], hRoomPos.transform.position, templates.leftHRooms[rand].transform.rotation);

                        if(hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                }
                else Debug.Log("Fill Room");
                //spawn left door
            }
            else if (openingDir == 4)
            {
                rand = Random.Range(0, templates.rightPRooms.Length);
                pRoomTest = Instantiate(templates.rightPRooms[rand], transform.position, templates.rightPRooms[rand].transform.rotation);
                if(pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.rightIRooms.Length);
                    iRoomTest = Instantiate(templates.rightIRooms[rand], iRoomPos.transform.position, templates.rightIRooms[rand].transform.rotation);

                    if(iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.rightHRooms.Length);
                        hRoomTest = Instantiate(templates.rightHRooms[rand], hRoomPos.transform.position, templates.rightHRooms[rand].transform.rotation);

                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                }
                else Debug.Log("Fill Room");
                //spawn right door
            }
            spawned = true;
            //may need to move later?
        }
        
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomSpawn"))
        {
            Destroy(gameObject);
        }
    }
}
