using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.ProBuilder.MeshOperations;

public class F_Enemies : MonoBehaviour
{
    private EventInstance playerBreathing;
    private EventInstance frogGrowl;
    private EventInstance playerStressSound;
    private EventInstance deathmusic;
    private Patroller enemies;
    private Transform player;
    private bool playedBreathing;
    [SerializeField] private float radius;
    private bool eventCalled;
    private bool played;
    
    void Start()
    {
        played = false;
        playerBreathing = RuntimeManager.CreateInstance("event:/Player/Breathing");
        enemies = GetComponent<Patroller>();
        player = GameObject.Find("First Person Player").GetComponent<Transform>();
        playerStressSound = RuntimeManager.CreateInstance("event:/Player/Breathing");
        RuntimeManager.AttachInstanceToGameObject(playerStressSound,transform, GetComponent<Rigidbody>());
        playerStressSound.start();
    }

    private void Update()
    {
        if (KillBox.playerIsDead == true)
        {
            playerStressSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }

        if (FinalKey.playerWins == true)
        {
            playerStressSound.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            F_Parameters.musicState = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
            F_Parameters.musicState = 0;
        }
    }

    private void OnDestroy()
    {
        playerStressSound.release();
    }
}

