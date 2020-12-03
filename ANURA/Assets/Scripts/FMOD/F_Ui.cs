using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class F_Ui : MonoBehaviour
{
    public void UIPress()
    {
        RuntimeManager.PlayOneShot("event:/Ui/UiPress",default);
    }
    public void UIHover()
    {
        RuntimeManager.PlayOneShot("event:/Ui/UiHover",default);
    }
    public void LockHover()
    {
        RuntimeManager.PlayOneShot("event:/Ui/LockHover",default);
    }
    public void StopDeathMusic()
    {
        KillBox.deathMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        F_AmbientMusic.played = false;
    }
    public void StopWinMusic()
    {
        FinalKey.winMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    public void RestartGame()
    {
        F_AmbientMusic.played = false;
        PauseMenu.paused.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        F_AmbientMusic.ambientMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
