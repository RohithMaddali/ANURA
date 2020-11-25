using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour
{
    public GameManager gm;

    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Player1"))
        {
            Debug.Log("caught player");
            gm.Caught(gameObject.transform.parent.gameObject, gameObject.transform.parent.gameObject.transform.parent.gameObject);
        }
    }
}
