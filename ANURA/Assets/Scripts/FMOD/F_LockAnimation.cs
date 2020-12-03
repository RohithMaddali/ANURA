using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class F_LockAnimation : MonoBehaviour
{
    public void FirstLock()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience/Lock/FirstUnlock", default);
    }
    public void FinalDoorUnlock()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience/Lock/Unlock", default);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ambience/PuzzleDoors/Doors", default);
    }
}
