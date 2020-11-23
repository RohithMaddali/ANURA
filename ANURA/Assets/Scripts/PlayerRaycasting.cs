using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distancetoTouch = 3;
    RaycastHit touchingObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * distancetoTouch, Color.blue);

        if (Input.GetKeyDown("e"))
        {
            Physics.Raycast(transform.position, transform.forward, out (touchingObject), distancetoTouch, 9);
            Debug.Log(touchingObject.collider.gameObject);
            if(touchingObject.collider.gameObject.tag == "Switch")
            {
                touchingObject.collider.gameObject.GetComponent<Switch>().Activate();
            }
            else if (touchingObject.collider.gameObject.tag == "BridgeSwitch")
            {
                touchingObject.collider.gameObject.GetComponent<BridgeSwitch>().Activate();
            }

        }

        if (Physics.Raycast(transform.position, transform.forward, out (touchingObject), distancetoTouch))
        {
            //Debug.Log("touching " + touchingObject.collider.gameObject.name);
            if (touchingObject.collider.gameObject.tag == "Switch" && Input.GetKeyDown("e"))
            {
                touchingObject.collider.gameObject.GetComponent<Switch>().Activate();
            }
            else if (touchingObject.collider.gameObject.tag == "BridgeSwitch" && Input.GetKeyDown("e"))
            {
                touchingObject.collider.gameObject.GetComponent<BridgeSwitch>().Activate();
            }
        }
    }
}
