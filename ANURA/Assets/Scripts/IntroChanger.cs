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
        StartCoroutine(end());
        Cursor.visible = false;
    }
    
    IEnumerator end()
    {
        yield return new WaitForSeconds(18f);
        SceneManager.LoadScene(2);
    }
}
