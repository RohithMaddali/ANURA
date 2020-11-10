using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSelf : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Deathtimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Deathtimer()
    {
        yield return new WaitForSeconds(0.6f);
        Destroy(gameObject);
    }
}
