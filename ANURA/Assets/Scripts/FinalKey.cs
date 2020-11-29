using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKey : MonoBehaviour
{
    public GameManager gm;
    public static bool playerWins;
    public static EventInstance winMusic;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>(); 
    }
    public void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player1" && gm.KeyCount == 3) 
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                winMusic = RuntimeManager.CreateInstance("event:/Music/WinMusic");
                winMusic.start();
                winMusic.release();
                F_Ambience.amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                SceneManager.LoadScene(2);
            }
        }
    }
}
