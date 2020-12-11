using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKey : MonoBehaviour
{
    public GameManager gm;
    public static bool playerWins;
    public static EventInstance winMusic;
    public Animator anim;
    public Animator wAnim;
    public Animator door;
    public bool firstEncounter;
    public int w;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        firstEncounter = false;
        wAnim = GameObject.FindGameObjectWithTag("Win").GetComponent<Animator>();
        door = GameObject.FindGameObjectWithTag("finalDoor").GetComponent<Animator>();
    }
    public void OnTriggerStay(Collider other) 
    {
        if(other.tag == "Player1" && gm.KeyCount == 3) 
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                w = 1;
                StartCoroutine(finalKeys());
            }
        }
        else if(other.tag == "Player1" && firstEncounter == false)
        {
            firstEncounter = true;
            anim.SetTrigger("First");
        }
        else if (other.tag == "Player1" && gm.KeyCount != 3)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                RuntimeManager.PlayOneShot("event:/Ambience/Lock/Locked", default);
            }
        }
    }

    IEnumerator finalKeys()
    {
        anim.SetTrigger("Final");
        door.SetTrigger("door");
        yield return new WaitForSeconds(2f);
        winMusic = RuntimeManager.CreateInstance("event:/Music/WinMusic");
        winMusic.start();
        winMusic.release();
        F_Ambience.amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        wAnim.SetTrigger("Win");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}
