using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider slider;
    public float fillValue = 0.5f;
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SliderUpdate()
    {
        fillValue = slider.value;
        gm.GetComponent<GameManager>().mouseSensitivityMultiplier = fillValue;
    }
}
