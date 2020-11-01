using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    GameObject[] enemies;
    public float toadHearingDistance = 10f;

             // perform attack on target  
             // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Toad");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("splash splash");
            foreach (GameObject toad in enemies)
            {
                float distance = Vector3.Distance(toad.transform.position, other.transform.position);
                if (distance < toadHearingDistance)
                {
                    //toad looks at and moves to player position
                    //coroutine to delay movment?
                    toad.transform.LookAt(other.transform.position);
                    Debug.Log("a toad heard that");
                    //replace this with move code on toad
                    toad.transform.Translate(Vector3.forward * Time.deltaTime);

                }
            }
        }
    }
}
