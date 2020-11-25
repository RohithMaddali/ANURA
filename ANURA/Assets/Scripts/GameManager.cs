using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.AI;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Caught(GameObject toad, GameObject room)
    {
        Debug.Log("turning on cursor");
        Cursor.lockState = CursorLockMode.None;
        Debug.Log("changing scene");
        SceneManager.LoadScene(1);
    }

    
    

    
    
}
