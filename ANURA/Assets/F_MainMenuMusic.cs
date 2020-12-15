using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_MainMenuMusic : MonoBehaviour
{
    private EventInstance menuMusic;
    private void Start()
    {
        menuMusic = RuntimeManager.CreateInstance("event:/Music/MenuMusic");
        menuMusic.start();
    }

    public void StartGame()
    {
        menuMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
}
