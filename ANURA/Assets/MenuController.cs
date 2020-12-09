﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void settings()
    {
        mainMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        settingMenu.SetActive(false);
    }
}
