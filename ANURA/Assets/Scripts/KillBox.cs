using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class KillBox : MonoBehaviour
{
    public GameManager gm;
    public Animator anim;
    public Animator death;
    public static bool playerIsDead;
    
    // Start is called before the first frame update
    void Start()
    {
        playerIsDead = false;
        gm = FindObjectOfType<GameManager>();
        death = GameObject.FindGameObjectWithTag("Death").GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.CompareTag("Player") || other.CompareTag("Player1"))
        {
            playerIsDead = true;
            ToadCaughtPlayer();
            StartCoroutine(killing());
        }
    }

    public void ToadCaughtPlayer()
    {
        Analytics.CustomEvent("gameOver", new Dictionary<string, object>
        {
            { "toad that caught", gameObject.transform.parent.gameObject.name },
            { "room toad is from", gameObject.transform.parent.gameObject.transform.parent.gameObject.name }
        });
    }

    IEnumerator killing()
    {
        anim.SetTrigger("Kill");
        death.SetTrigger("Death");
        yield return new WaitForSeconds(1f);
        Debug.Log("caught player");
        gm.Caught(gameObject.transform.parent.gameObject, gameObject.transform.parent.gameObject.transform.parent.gameObject);
    }
}
