﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distancetoTouch;
    RaycastHit touchingObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, this.transform.forward * distancetoTouch, Color.blue);

        if(Physics.Raycast(this.transform.position, this.transform.forward, out (touchingObject), distancetoTouch))
        {
            //Debug.Log("touching " + touchingObject.collider.gameObject.name);
            if (touchingObject.collider.gameObject.tag == "Switch" && Input.GetKeyDown("e"))
            {
                touchingObject.collider.gameObject.GetComponent<Switch>().Activate();
            }
        }
    }
}