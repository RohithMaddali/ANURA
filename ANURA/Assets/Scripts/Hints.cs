using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hints : MonoBehaviour
{
    public Text hints;
    public LevelManager LV;
    public string[] hint;
    public int number, previousnum;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        LV = GameObject.FindGameObjectWithTag("LM").GetComponent<LevelManager>();
        if (LV.levelWorks != true)
        {
            if (time == 0)
            {
                StartCoroutine(randomhint());
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(LV.levelWorks != true)
        {
            if (time == 0)
            {
                StartCoroutine(randomhint());
            }
        }

        else if (LV.levelWorks)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator randomhint()
    {
        number = Random.Range(0, hint.Length);
        if (previousnum != number)
        {
            hints.text = hint[number];
            previousnum = number;
            time += Time.deltaTime;
            yield return new WaitForSeconds(2f);
            time = 0;
        }
    }
}
