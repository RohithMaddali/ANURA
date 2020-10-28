using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public bool isclosed = true;
    public bool moving = false;
    public Vector3 openPos;
    public Vector3 closePos;
    private Vector3 startPos;
    private Vector3 target;
    public float speed = 6f;
    public float openHeight = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isclosed)
        {
            closePos = transform.position;
            openPos.x = transform.position.x;
            openPos.y = transform.position.y + openHeight;
            openPos.z = transform.position.z;
        }else if (!isclosed)
        {
            openPos = transform.position;
            closePos.x = transform.position.x;
            closePos.y = transform.position.y - openHeight;
            closePos.z = transform.position.z;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            Debug.Log("moving");
        }
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            moving = false;
            if(isclosed)
            {
                isclosed = false;
            }else if (!isclosed)
            {
                isclosed = true;
            }
            target = new Vector3(0,0,0);
            Debug.Log("stopped moving");
        }
    }

    public void Open()
    {
        target = openPos;
        startPos = closePos;
        moving = true;
        Debug.Log("opening");
    }

    public void Close()
    {
        target = closePos;
        startPos = openPos;
        moving = true;
        Debug.Log("closing");
    }
}
