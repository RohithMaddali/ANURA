using System;
using System.Collections;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class F_Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField]
    private float walkingSpeed = 1;
    [SerializeField]
    private float walkingBackwardsSpeed = 1;
    private F_Music music;
    private bool played;
    private EventInstance stressed;
    public LayerMask lm;
    float[] values = new float[1];
    private float material;
    private void Start()
    {
        InvokeRepeating("WalkingFootsteps",0,walkingSpeed);
        playerMovement = GetComponent<PlayerMovement>();
        music = GetComponent<F_Music>();
        stressed = RuntimeManager.CreateInstance("event:/Player/Breathing");
    }

    private void Update()
    {
        MaterialCheck();
    }

    void WalkingFootsteps()
    {
        if (playerMovement.isMoving == true)
        {
            EventInstance footsteps = RuntimeManager.CreateInstance("event:/Player/P_Footsteps");
            footsteps.setParameterByName("Material", material, false);
            footsteps.start();
            footsteps.release();
        }
    }
    void MaterialCheck()
    {
        float dist = 3f;
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, dist, lm);

        switch (hit.collider.tag)
        {
            case "Concrete":
                material = 0;
                Debug.Log("Concrete");
                break;
            case "Water":
                material = 1;
                break;
            default:
                material = 0;
                break;
        }
    }
    
}
