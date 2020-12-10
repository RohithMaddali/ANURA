using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(end());
    }
    
    IEnumerator end()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene(1);
    }
}
