using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
            ActivateMenu();
        }

        else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        cammie = GameObject.FindGameObjectWithTag("MainCamera");
        cammie.GetComponent<HeadBobber>().bobbingSpeed = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        Time.timeScale = 1;
        cammie = GameObject.FindGameObjectWithTag("MainCamera");
        cammie.GetComponent<HeadBobber>().bobbingSpeed = 0.07f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void QuitGame()
    {
        //Add "Are you sure you want to quit? progress will be lost. Y/N later
        Application.Quit();
    }

    public void GiveHint()
    {
        //find the text component of the hovered UI
        //put UI in the loaction of player's cursor

    }
}
