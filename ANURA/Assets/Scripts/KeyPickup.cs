using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameManager gm;
    public GameObject[] PRT;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        foreach (GameObject toad in PRT)
        {
            toad.SetActive(false);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1")
        {
            gm.GetComponent<GameManager>().keyRange = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                foreach (GameObject toad in PRT)
                {
                    toad.SetActive(true);
                }
                FMODUnity.RuntimeManager.PlayOneShot("event:/Music/PuzzleRoomSuccess");
                gm.KeyCount += 1;
                Destroy(gameObject);
                gm.GetComponent<GameManager>().keyRange = false;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1")
        {
            gm.GetComponent<GameManager>().keyRange = false;
        }
    }
}
