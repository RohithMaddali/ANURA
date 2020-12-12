using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewControl : MonoBehaviour
{
    //set mouse sensitivity
    public float mouseSensitivity = 250f;

    //find gamemanager
    public GameObject gm;

    //assign playerbody
    public Transform playerBody;
    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        //control the mouse sensitivity
        mouseSensitivity = (50 + (gm.GetComponent<GameManager>().mouseSensitivityMultiplier * 400));

        //track mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //move player viewpoint
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -75f, 65f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
