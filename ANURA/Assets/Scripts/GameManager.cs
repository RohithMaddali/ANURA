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
        ToadCaughtPlayer(toad, room);
    }

    public void ToadSawPlayer(GameObject enemy)
    {

        Analytics.CustomEvent("PlayerSpotted", new Dictionary<string, object>
        {
            {"toad", enemy },
            {"room", enemy.transform.parent.gameObject }
        });
    }
    public void ToadCaughtPlayer(GameObject toad, GameObject room)
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "toad that caught", toad },
            { "room toad is from", room }
        });
    }

    
    
}
