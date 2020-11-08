﻿using System.Collections;
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
    GameManager gm;

    private RoomTemplates templates;
    private int rand;
    private int roomtype;
    private float randTimer;
    public bool spawned = false;
    public bool spawnNext;
    
    // Start is called before the first frame update
    void Start()
    {
        
        gm = FindObjectOfType<GameManager>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 2f);
    }

    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDir == 1)
            {
                //spawn bottom door
                Debug.Log("Spawn temp pRoom");
                StartCoroutine(WallTest(pRoomTest, iRoomTest, hRoomTest, templates.bottomPRooms, templates.bottomIRooms, templates.bottomHRooms, iRoomPos, hRoomPos));
                
                /*
                //rand = Random.Range(0, templates.bottomPRooms.Length);
                //pRoomTest = Instantiate(templates.bottomPRooms[rand], transform.position, templates.bottomPRooms[rand].transform.rotation);
                //check that rooms trigger
                if (pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    //if triggered destroy and spawn I room at I room pos
                    Debug.Log("Spawn temp iRoom");
                    Destroy(pRoomTest);
                    BuildTemp(iRoomTest, templates.bottomIRooms, iRoomPos);
                    //rand = Random.Range(0, templates.bottomIRooms.Length);
                    //iRoomTest = Instantiate(templates.bottomIRooms[rand], iRoomPos.transform.position, templates.bottomIRooms[rand].transform.rotation);
                    //check room trigger
                    if (iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        //if triggered destroy and spawn h room at h room pos
                        Destroy(iRoomTest);
                        Debug.Log("Spawn temp hRoom");
                        BuildTemp(hRoomTest, templates.bottomHRooms, hRoomPos);
                        //rand = Random.Range(0, templates.bottomHRooms.Length);
                        //hRoomTest = Instantiate(templates.bottomHRooms[rand], hRoomPos.transform.position, templates.bottomHRooms[rand].transform.rotation);
                        //check room trigger
                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            //if triggered spawn collapsed doorway
                            Destroy(hRoomTest);
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
                */
            }
            else if (openingDir == 2)
            {
                Debug.Log("Spawn temp pRoom");
                StartCoroutine(WallTest(pRoomTest, iRoomTest, hRoomTest, templates.topPRooms, templates.topIRooms, templates.topHRooms, iRoomPos, hRoomPos));
                /*
                rand = Random.Range(0, templates.topPRooms.Length);
                pRoomTest = Instantiate(templates.topPRooms[rand], transform.position, templates.topPRooms[rand].transform.rotation);
                if (pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Debug.Log("Spawn temp iRoom");
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.topIRooms.Length);
                    iRoomTest = Instantiate(templates.topIRooms[rand], iRoomPos.transform.position, templates.topIRooms[rand].transform.rotation);

                    if (iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        //if triggered destroy and spawn h room at h room pos
                        Debug.Log("Spawn temp hRoom");
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.topHRooms.Length);
                        hRoomTest = Instantiate(templates.topHRooms[rand], hRoomPos.transform.position, templates.topHRooms[rand].transform.rotation);

                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            //if triggered spawn collapsed doorway
                            Destroy(hRoomTest);
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                    // spawn top door
                }
                else Debug.Log("Fill Room");*/
            }

            else if (openingDir == 3)
            {
                Debug.Log("Spawn temp pRoom");
                StartCoroutine(WallTest(pRoomTest, iRoomTest, hRoomTest, templates.leftPRooms, templates.leftIRooms, templates.leftHRooms, iRoomPos, hRoomPos));
                /*
                rand = Random.Range(0, templates.leftPRooms.Length);
                pRoomTest = Instantiate(templates.leftPRooms[rand], transform.position, templates.leftPRooms[rand].transform.rotation);
                if(pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Debug.Log("Spawn temp iRoom");
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.leftIRooms.Length);
                    iRoomTest = Instantiate(templates.leftIRooms[rand], iRoomPos.transform.position, templates.leftIRooms[rand].transform.rotation);

                    if(iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        Debug.Log("Spawn temp hRoom");
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.leftHRooms.Length);
                        hRoomTest = Instantiate(templates.leftHRooms[rand], hRoomPos.transform.position, templates.leftHRooms[rand].transform.rotation);

                        if(hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            Destroy(hRoomTest);
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                }
                else Debug.Log("Fill Room");
                //spawn left door*/
            }
            else if (openingDir == 4)
            {
                Debug.Log("Spawn temp pRoom");
                StartCoroutine(WallTest(pRoomTest, iRoomTest, hRoomTest, templates.rightPRooms, templates.rightIRooms, templates.rightHRooms, iRoomPos, hRoomPos));
                /*
                rand = Random.Range(0, templates.rightPRooms.Length);
                pRoomTest = Instantiate(templates.rightPRooms[rand], transform.position, templates.rightPRooms[rand].transform.rotation);
                if(pRoomTest.GetComponent<SpaceCheck>().fits == false)
                {
                    Debug.Log("Spawn temp iRoom");
                    Destroy(pRoomTest);
                    rand = Random.Range(0, templates.rightIRooms.Length);
                    iRoomTest = Instantiate(templates.rightIRooms[rand], iRoomPos.transform.position, templates.rightIRooms[rand].transform.rotation);

                    if(iRoomTest.GetComponent<SpaceCheck>().fits == false)
                    {
                        Debug.Log("Spawn temp hRoom");
                        Destroy(iRoomTest);
                        rand = Random.Range(0, templates.rightHRooms.Length);
                        hRoomTest = Instantiate(templates.rightHRooms[rand], hRoomPos.transform.position, templates.rightHRooms[rand].transform.rotation);

                        if (hRoomTest.GetComponent<SpaceCheck>().fits == false)
                        {
                            Destroy(hRoomTest);
                            Debug.Log("close doorway");
                        }
                        else Debug.Log("Fill Room");
                    }
                    else Debug.Log("Fill Room");
                }
                else Debug.Log("Fill Room");
                //spawn right door*/
            }
            
            //may need to move later?
        }
        
        
    }

    void BuildRoom(GameObject room, GameObject[] roomList, Transform pos)
    {
        rand = Random.Range(0, roomList.Length);
        room = Instantiate(roomList[rand], pos.transform.position, roomList[rand].transform.rotation);
        
        //StartCoroutine(WallTest(room, roomList, pos));
    }

    IEnumerator WallTest(GameObject pRoom, GameObject iRoom, GameObject hRoom, GameObject[] pRoomList, GameObject[] iRoomList, GameObject[] hRoomList, Transform iPos, Transform hPos)
    {
        if(gm.roomCount < 4)
        {
            roomtype = Random.Range(1, 3);
            if(roomtype == 1)
            {
                rand = Random.Range(0, iRoomList.Length);
                iRoom = Instantiate(iRoomList[rand], iPos.transform.position, iRoomList[rand].transform.rotation);
                spawned = true;
                gm.roomCount++;
            }
            if(roomtype == 2)
            {
                rand = Random.Range(0, hRoomList.Length);
                iRoom = Instantiate(hRoomList[rand], hPos.transform.position, hRoomList[rand].transform.rotation);
                spawned = true;
                gm.roomCount++;
            }


        }
        else
        {
            randTimer = Random.Range(0.1f, 2.9f);
            rand = Random.Range(0, pRoomList.Length);
            pRoom = Instantiate(pRoomList[rand], transform.position, pRoomList[rand].transform.rotation);
            yield return new WaitForSeconds(1);

            if (pRoom.GetComponent<SpaceCheck>().fits == true && gm.roomCount > 4)
            {
                Debug.Log("Fill pRoom");
                spawned = true;
                gm.roomCount++;
                //create room
            }
            else
            {
                Destroy(pRoom);
                rand = Random.Range(0, iRoomList.Length);
                transform.position = iPos.transform.position;
                iRoom = Instantiate(iRoomList[rand], transform.position, iRoomList[rand].transform.rotation);
                yield return new WaitForSeconds(1);
                if (iRoom.GetComponent<SpaceCheck>().fits == true)
                {
                    Debug.Log("Fill iRoom");
                    spawned = true;
                    gm.roomCount++;
                    //create room
                }
                else
                {
                    Destroy(iRoom);
                    rand = Random.Range(0, hRoomList.Length);
                    transform.position = hPos.transform.position;
                    hRoom = Instantiate(hRoomList[rand], transform.position, hRoomList[rand].transform.rotation);
                    yield return new WaitForSeconds(1);
                    if (hRoom.GetComponent<SpaceCheck>().fits == true)
                    {
                        Debug.Log("Fill hRoom");
                        spawned = true;
                        gm.roomCount++;
                    }
                    else
                    {
                        Destroy(hRoom);
                        Debug.Log("Insert broken hallway");
                        spawned = true;
                    }
                }

            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomSpawn"))
        {
            spawned = true;
            //gameObject.SetActive(false);
        }
        if (other.CompareTag("RoomSpawn"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Destroy(gameObject);
                Debug.Log("create sealed walls");
            }
                
        }
        if (other.CompareTag("TempRoom") && other.GetComponent<SpaceCheck>().fits)
        {
            spawned = true;
            Debug.Log("spawner inside another room");
            //gameObject.SetActive(false);
        }
    }

}