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
    private Patroller enemies;
    private Transform player;
    private bool playedBreathing;
    [SerializeField] private float radius;
    private bool eventCalled;

    public delegate void enemyIsNear();
    public static event enemyIsNear musicPlay; 
    public delegate void enemyIsNearStop();
    public static event enemyIsNearStop musicstop;

    void Start()
    {
        playerBreathing = RuntimeManager.CreateInstance("event:/Player/Breathing");
        enemies = GetComponent<Patroller>();
        player = GameObject.Find("First Person Player").GetComponent<Transform>();
        frogGrowl = RuntimeManager.CreateInstance("event:/Enemy/EnemySounds");
        RuntimeManager.AttachInstanceToGameObject(frogGrowl, transform, GetComponent<Rigidbody>());
        frogGrowl.start();
        frogGrowl.release();
        playerStressSound = RuntimeManager.CreateInstance("event:/Player/Breathing");
        RuntimeManager.AttachInstanceToGameObject(playerStressSound,transform, GetComponent<Rigidbody>());
        playerStressSound.start();
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
}

