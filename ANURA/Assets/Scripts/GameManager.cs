using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Security.Cryptography;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int KeyCount;
    public int Scene;
    public float t, timer;
    public bool toadSeen = false;
    public bool seeSwitch = false;
    public bool keyRange = false;

    public float mouseSensitivityMultiplier = 0.5f;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        //SceneManager.sceneLoaded += OnSceneLoad;
    }

    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            Time.timeScale = 1;
            t += Time.deltaTime;
            if(t>timer)
            {
                SceneManager.LoadScene("Room GeneratorTester");
            }
        }
    }

    public void Caught(GameObject toad, GameObject room)
    {
        Debug.Log("changing scene");
        SceneManager.LoadScene(3);
    }


    /*void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);
        if (scene.buildIndex == 5)
        {
                Debug.Log("Loaded Intro Level. Leaving in T minus 18 seconds");
                StartCoroutine(End());
        }
        if(scene.buildIndex != 2)
        {
            toadSeen = false;
            seeSwitch = false;
            keyRange = false;
            KeyCount = 0;
        }
    }*/

    IEnumerator End()
    {

        Debug.Log("Coroutine Started");
        //SceneManager.sceneLoaded -= OnSceneLoad;
        yield return new WaitForSeconds(5f);
        Debug.Log("Timer Ended");
        SceneManager.LoadScene("Room GeneratorTester");

    }



}
