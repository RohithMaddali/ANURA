using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalKey : MonoBehaviour
{
    public GameManager gm;
    public static bool playerWins;
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
                F_Ambience.amb.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
                SceneManager.LoadScene(2);
            }
        }
    }
}
