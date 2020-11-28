using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_AmbientMusic : MonoBehaviour
{
    public static EventInstance ambientMusic;
    static bool played;

    void Awake()
    {
        if (played == false)
        {   
            ambientMusic = RuntimeManager.CreateInstance("event:/Music/Ambience2");
            ambientMusic.start();
            ambientMusic.release();
            played = true;
        }
    }
}
