using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //serialize field makes private gameobjects viewable in editor
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    private GameObject cammie;
    public GameManager gameManager;

    public GameObject locktip;
    public GameObject keytip1;
    public GameObject keytip2;
    public GameObject keytip3;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

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

        //this else if chain will be kind of long but due to time constraints I'll do it this way for now
        if (gameManager.GetComponent<GameManager>().KeyCount == 0)
        {
            locktip.SetActive(true);
        }
        else if (gameManager.GetComponent<GameManager>().KeyCount == 1)
        {
            locktip.SetActive(false);
            keytip1.SetActive(true);
        }
        else if (gameManager.GetComponent<GameManager>().KeyCount == 2)
        {
            keytip1.SetActive(false);
            keytip2.SetActive(true);
        }
        else if (gameManager.GetComponent<GameManager>().KeyCount == 3)
        {
            keytip2.SetActive(false);
            keytip3.SetActive(true);
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
    public void restart()
    {
        gameManager.KeyCount = 0;
        SceneManager.LoadScene(0);
    }
}
