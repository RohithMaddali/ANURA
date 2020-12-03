using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider ai)
    {
        //TODO: Enable AI on toad
        throw new NotImplementedException();
        Debug.Log("Enable AI");
    }

    private void OnTriggerExit(Collider ai)
    {
        //TODO: Disable AI on toad
        throw new NotImplementedException();
        Debug.Log("Disable AI");
    }

    void EnemyTracker()
    {
        //TODO: Experiment with object tracker (Possibly not to be implemented)
    }
}
