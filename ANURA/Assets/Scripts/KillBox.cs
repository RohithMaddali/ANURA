using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.Analytics;

public class KillBox : MonoBehaviour
{
    public GameManager gm;
    public Animator anim;
    public Animator death;
    public static bool playerIsDead;
    public static EventInstance deathMusic;
    public Patroller P;
    
    void Start()
    {
        playerIsDead = false;
        gm = FindObjectOfType<GameManager>();
        death = GameObject.FindGameObjectWithTag("Death").GetComponent<Animator>();
        P = GetComponentInParent<Patroller>();
    }

    void Update()
    {
        if(P.walk == 0)
        {
            anim.SetBool("Hop", false);
        }
        else if(P.walk == 1)
        {
            anim.SetBool("Hop", true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Player1"))
        {
            //F_Ambience.amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            deathMusic = RuntimeManager.CreateInstance("event:/Music/DeathMusic");
            deathMusic.start();
            deathMusic.release();
            RuntimeManager.PlayOneShot("event:/Player/Death",default);
            ToadCaughtPlayer();
            StartCoroutine(killing());
        }
    }
    public void ToadCaughtPlayer()
    {
        playerIsDead = true;
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "toad that caught", gameObject.transform.parent.gameObject.name },
            { "room toad is from", gameObject.transform.parent.gameObject.transform.parent.gameObject.name }
        });
    }
    IEnumerator killing()
    {
        anim.SetTrigger("Kill");
        death.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Debug.Log("caught player");
        gm.Caught(gameObject.transform.parent.gameObject, gameObject.transform.parent.gameObject.transform.parent.gameObject);
    }
}
