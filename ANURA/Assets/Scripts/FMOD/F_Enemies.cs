using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
public class F_Enemies : MonoBehaviour
{
    private EventInstance playerBreathing;
    private Patroller enemies;
    private bool playedBreathing;
    
    void Start()
    {
        playerBreathing = RuntimeManager.CreateInstance("event:/Player/Breathing");
        enemies = GetComponent<Patroller>();
    }

    private void Update()
    {
        CheckEnemyState(); 
    }

    void CheckEnemyState()
    {
        if (enemies.action == Patroller.Behaviour.chasing)
        {
            StartCoroutine(BreathingIntencity());
            Debug.Log("BREATHING");
            playedBreathing = true;
        }
    }

    IEnumerator BreathingIntencity()
    {
            playerBreathing.start();
            yield return new WaitForSeconds(5);
            playerBreathing.setParameterByName("StressLevel", 1, false);
            yield return new WaitForSeconds(5);
            playerBreathing.setParameterByName("StressLevel", 2, false);
        }
    }
