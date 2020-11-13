using System;
using System.Collections;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

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
    float[] values = new float[1];
    private void Start()
    {
        InvokeRepeating("WalkingFootsteps",0,walkingSpeed);
        playerMovement = GetComponent<PlayerMovement>();
        music = GetComponent<F_Music>();
        stressed = RuntimeManager.CreateInstance("event:/Player/Breathing");
    }
    void WalkingFootsteps()
    {
        if (playerMovement.isMoving == true)
        {
            RuntimeManager.PlayOneShot("event:/Player/P_Footsteps",default);
        }
    }

    private void Update()
    {
        HeavyBreathing();
    }

    void HeavyBreathing()
    {
        if (playerMovement.isMoving == false && music.enemyIsNear == false && played == false)
        {
            Debug.Log("heavy breathing");
            StartCoroutine(BreathingIntencity());
            played = true;
        }
        if (playerMovement.isMoving == true)
        {
            stressed.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            played = false;
        }
        
    }
    IEnumerator BreathingIntencity()
    {
        yield return new WaitForSeconds(5);
        if (playerMovement.isMoving == false && music.enemyIsNear == false)
        {
            stressed.start();
            stressed.release();
            yield return new WaitForSeconds(5);
            stressed.setParameterByName("StressLevel", 1, false);
            yield return new WaitForSeconds(6);
            stressed.setParameterByName("StressLevel", 2, false);
        }
    }
}
