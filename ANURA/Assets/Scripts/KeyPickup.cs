using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player1")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                gm.KeyCount += 1;
                Destroy(gameObject);
            }
        }
    }
}
