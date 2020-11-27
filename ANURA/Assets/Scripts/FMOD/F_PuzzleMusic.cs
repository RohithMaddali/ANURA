using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_PuzzleMusic : MonoBehaviour
{
    private bool played;
       private void OnTriggerEnter(Collider other)
       {
              if (other.gameObject.CompareTag("Player1") && played == false)
              {
                    RuntimeManager.PlayOneShot("event:/Music/PuzzleRoom", default);
                    played = true;
              }
       }
}
