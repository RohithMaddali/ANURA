using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoom : MonoBehaviour
{
    public int openingDir;

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;
    private GameObject room;
    LevelManager lm;

    // Start is called before the first frame update
    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            if(openingDir == 1)
            {
                rand = Random.Range(0, templates.bottomIRooms.Length);
                room = Instantiate(templates.bottomIRooms[rand], transform.position, templates.bottomIRooms[rand].transform.rotation);
                lm.roomCount++;
            }
            if (openingDir == 2)
            {
                rand = Random.Range(0, templates.topIRooms.Length);
                room = Instantiate(templates.topIRooms[rand], transform.position, templates.topIRooms[rand].transform.rotation);
                lm.roomCount++;
            }
            if (openingDir == 3)
            {
                rand = Random.Range(0, templates.leftIRooms.Length);
                room = Instantiate(templates.leftIRooms[rand], transform.position, templates.leftIRooms[rand].transform.rotation);
                lm.roomCount++;
            }
            if (openingDir == 4)
            {
                rand = Random.Range(0, templates.rightIRooms.Length);
                room = Instantiate(templates.rightIRooms[rand], transform.position, templates.rightIRooms[rand].transform.rotation);
                lm.roomCount++;
            }
            spawned = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RoomSpawn"))
        {
            
            spawned = true;
        }
        if (other.CompareTag("TempRoom") && other.GetComponent<SpaceCheck>().fits)
        {
            spawned = true;
            Debug.Log("spawner inside another room");
        }
    }
}
