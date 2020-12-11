using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public int sceneNum;
    public GameManager gm;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        gm.KeyCount = 0;
        SceneManager.LoadScene(sceneNum);
    }
}
