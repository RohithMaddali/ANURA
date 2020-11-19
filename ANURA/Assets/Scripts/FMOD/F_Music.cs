
using System;
using System.Collections;
using FMOD.Studio;
using FMODUnity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.ProBuilder.MeshOperations;


public class F_Music : MonoBehaviour
{
    private EventDescription eDS;
    private PARAMETER_DESCRIPTION[] pDS = new PARAMETER_DESCRIPTION[5];
    public static PARAMETER_ID[] pIDS = new PARAMETER_ID[5];
    public static EventInstance music;
    float[] values01 = new float[5];
    float[] values02 = new float[5];
    [SerializeField] private float radius;
    private PlayerMovement pMovement;
    [HideInInspector] 
    public bool playedMusic;
    [HideInInspector]
    public bool enemyIsNear = false;


    public MyStruct[] parameterValues;
    [System.Serializable]
    public struct MyStruct {
        public string title;
        public string info;
        public float[] number;
    }
    
    private void Start()
    {
        pMovement = GetComponent<PlayerMovement>();
        GetParameterIDS();
        music = RuntimeManager.CreateInstance("event:/Music/AttackMusic 2");
        music.start();
        music.release();
    }

    private void Update()
    {
        PlayStationaryMusic();
    }

    void PlayStationaryMusic()
    {
        if (pMovement.isMoving == false && playedMusic == false && F_Parameters.musicState == 1)
        {
            Debug.Log("playmusic");
            StartCoroutine(MusicTimeToTrigger());
            playedMusic = true;
        }
        if (F_Parameters.musicState == 0)
        {
            music.setParametersByIDs(pIDS, parameterValues[0].number, 5, false);
            playedMusic = false;
        }
    }

    IEnumerator MusicTimeToTrigger()
    {
        yield return new WaitForSeconds(5);
        if (pMovement.isMoving == false)
        {
            music.setParametersByIDs(pIDS, parameterValues[1].number, 5, false);
            yield return new WaitForSeconds(7);
            music.setParametersByIDs(pIDS, parameterValues[2].number, 5, false);
            yield return new WaitForSeconds(7);
            music.setParametersByIDs(pIDS, parameterValues[3].number, 5, false);
        }
    }
    
    void GetParameterIDS()
    {
        eDS = RuntimeManager.GetEventDescription("event:/Music/AttackMusic");
        eDS.getParameterDescriptionByName("Percussion", out pDS[0]);
        eDS.getParameterDescriptionByName("Percussion2", out pDS[1]);
        eDS.getParameterDescriptionByName("Choir", out pDS[2]);
        eDS.getParameterDescriptionByName("String1", out pDS[3]);
        eDS.getParameterDescriptionByName("String2", out pDS[4]);

        for (int i = 0; i < pDS.Length; i++)
        {
            pIDS[i] = pDS[i].id;
        }
    }

}
