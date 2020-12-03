using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System.Security.Cryptography;

public class GameManager : MonoBehaviour
{
    public int KeyCount;
    public bool toadSeen = false;
    public bool seeSwitch = false;
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Caught(GameObject toad, GameObject room)
    {
        Debug.Log("changing scene");
        SceneManager.LoadScene(2);
    }

    




}
