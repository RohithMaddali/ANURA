using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawbridge : MonoBehaviour
{
    public bool isclosed = true;
    public bool moving = false;
    public Quaternion openRot;
    public Quaternion closeRot;
    private Quaternion startRot;
    private Quaternion target;
    public float speed = 6f;
    //public float openHeight = 5f;
    void Update()
    {
        if (moving)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target, speed * Time.deltaTime);
            Debug.Log("moving");
        }
        if (Quaternion.Angle(transform.rotation, target) < 0.1f)
        {
            moving = false;
            if(isclosed)
            {
                isclosed = false;
            }
            else if (!isclosed)
            {
                isclosed = true;
            }
            target = new Quaternion(0,0,0,0);
            Debug.Log("stopped moving");
        }
    }

    public void Open()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Ambience/PuzzleDoors/Doors", this.gameObject);
        target = openRot;
        startRot = closeRot;
        moving = true;
        Debug.Log("opening");
    }

    public void Close()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached("event:/Ambience/PuzzleDoors/DoorsClose", this.gameObject);
        target = closeRot;
        startRot = openRot;
        moving = true;
        Debug.Log("closing");
    }
}
