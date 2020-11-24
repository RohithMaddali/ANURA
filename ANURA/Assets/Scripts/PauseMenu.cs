using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //serialize field makes private gameobjects viewable in editor
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    private GameObject cammie;

    // Update is called once per frame
    private void Update()
    {
        //check for the esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0;
            cammie = GameObject.FindGameObjectWithTag("MainCamera");
            cammie.GetComponent<HeadBobber>().bobbingSpeed = 0;
            ActivateMenu();
        }

        else
        {
            Time.timeScale = 1;
            cammie = GameObject.FindGameObjectWithTag("MainCamera");
            cammie.GetComponent<HeadBobber>().bobbingSpeed = 0.07f;
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        pauseMenuUI.SetActive(true);
    }

    void DeactivateMenu()
    {
        pauseMenuUI.SetActive(false);
    }
}
