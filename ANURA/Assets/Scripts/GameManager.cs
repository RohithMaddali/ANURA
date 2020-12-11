using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public int KeyCount;
    public int Scene;
    public float t, timer;
    public bool toadSeen = false;
    public bool seeSwitch = false;
    public bool keyRange = false;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Caught(GameObject toad, GameObject room)
    {
        Debug.Log("changing scene");
        SceneManager.LoadScene(3);
    }

    void Update()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
        if (Scene == 5)
        {
            t += Time.deltaTime;
            if (t > timer)
            {
                t = 0;
                SceneManager.LoadScene(2);
            }
        }
    }





}
