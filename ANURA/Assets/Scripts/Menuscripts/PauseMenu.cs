using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static EventInstance paused;
    //serialize field makes private gameobjects viewable in editor
    [SerializeField] private GameObject pauseMenuUI;

    [SerializeField] private bool isPaused;

    public bool menuopened = false;

    private GameObject cammie;
    public GameManager gameManager;
    public LevelManager lm;

    //keep track of active icons
    public GameObject locktip;
    public GameObject locktext;
    public GameObject keytip1;
    public GameObject keytext1;
    public GameObject keytip2;
    public GameObject keytext2;
    public GameObject keytip3;
    public GameObject toadtip;

    //control popups
    public GameObject escpop;
    public GameObject intpop;
    public GameObject keypop;

    void Start()
    {
        lm = FindObjectOfType<LevelManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        paused = RuntimeManager.CreateInstance("snapshot:/Paused");
    }

    // Update is called once per frame
    private void Update()
    {
        //check for the esc key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            paused.start();
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActivateMenu();
            menuopened = true;
        }
        else
        {
            paused.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
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
            locktext.SetActive(false);
            keytip1.SetActive(true);
        }
        else if (gameManager.GetComponent<GameManager>().KeyCount == 2)
        {
            keytip1.SetActive(false);
            keytext1.SetActive(false);
            keytip2.SetActive(true);
        }
        else if (gameManager.GetComponent<GameManager>().KeyCount == 3)
        {
            keytip2.SetActive(false);
            keytext2.SetActive(false);
            keytip3.SetActive(true);
        }
        //keep track of if the player has seen the toad
        if (gameManager.GetComponent<GameManager>().toadSeen == true)
        {
            toadtip.SetActive(true);
        }

        //make the popup fade away
        if (menuopened == true)
        {
            StartCoroutine(FadeImage(true));
        }

        if (gameManager.GetComponent<GameManager>().seeSwitch == true)
        {
            StartCoroutine(FadePrompt(false,intpop));
        }
        else
        {
            StartCoroutine(FadePrompt(true,intpop));
        }

        if (gameManager.GetComponent<GameManager>().keyRange == true)
        {
            StartCoroutine(FadePrompt(false, keypop));
        }
        else
        {
            StartCoroutine(FadePrompt(true, keypop));
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        if (lm.levelBuilt)
        {
            cammie = GameObject.FindGameObjectWithTag("MainCamera");
            cammie.GetComponent<HeadBobber>().bobbingSpeed = 0;
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {

        Time.timeScale = 1;
        if (lm.levelBuilt)
        {
            cammie = GameObject.FindGameObjectWithTag("MainCamera");
            cammie.GetComponent<HeadBobber>().bobbingSpeed = 0.07f;
        }
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
        SceneManager.LoadScene(2);
    }
    public void mainMneu()
    {
        gameManager.t = 0;
        Time.timeScale = 1;
        gameManager.KeyCount = 0;
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += 0.05f)
            {
                // set color with i as alpha
                escpop.GetComponent<CanvasGroup>().alpha -= i;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
        /*else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 0.05f)
            {
                // set color with i as alpha
                escpop.GetComponent<CanvasGroup>().alpha += i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }*/
    }

    IEnumerator FadePrompt(bool fadeAway, GameObject myPrompt)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 0; i <= 1; i += 0.05f)
            {
                // set color with i as alpha
                myPrompt.GetComponent<CanvasGroup>().alpha -= i;
                yield return new WaitForSecondsRealtime(0.1f);
            }
        }
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += 0.05f)
            {
                // set color with i as alpha
                myPrompt.GetComponent<CanvasGroup>().alpha += i;
                yield return new WaitForSecondsRealtime(0.05f);
            }
        }
    }
}
