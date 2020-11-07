﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //find character controller
    public CharacterController controller;

    //initialize speed
    public float speed = 5f;

    //handle gravity
    public float gravity = -9.8f;

    //give player weight
    public float weight = 5f;

    //initialize ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    //control player y speed
    public Vector3 velocity;
    bool isGrounded;
    [HideInInspector]
    public bool isMoving;

    void Update()
    {
        //get movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //check if grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Checks if player is moving. 
        if (z >= 0.01 || x >= 0.01 || z <= -0.01 || x <= -0.01) 
        {
            isMoving = true;
        }
        else if (z == 0  || x == 0)
        {
            isMoving = false;
        }

        //apply input
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * (speed * Time.deltaTime));
    
        //apply gravity
        velocity.y += gravity * Time.deltaTime * weight;
        controller.Move(velocity * Time.deltaTime);
    }
}
