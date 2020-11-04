using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentPoint;
    public Transform[] patrolPoints;
    public float moveSpeed;
    GameObject player;
    public Vector3 lastKnownPos;
    public bool patrolling = true;
    public bool investigating;
    public bool chasing;
    public bool searching;
    public float time;
    public float searchtimer = 10;
    
    void Start()
    {
        transform.position = patrolPoints[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolling)
        {
            transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

            if (transform.position == patrolPoints[currentPoint].position)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
            }
        }

        if (investigating)
        {
            Quaternion rotTarget = Quaternion.LookRotation(lastKnownPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 40 * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, lastKnownPos, moveSpeed * Time.deltaTime);
            
            Debug.Log("a toad heard that");
            if(transform.position == lastKnownPos)
            {
                investigating = false;
                Search();
            }
        }

        if (chasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }

        if (searching)
        {

            time += Time.deltaTime;
            if (time >= searchtimer)
            {
                searching = false;
                chasing = false;
                investigating = false;
                patrolling = true;
            }
        }
    }
    IEnumerator RoarAndChase()
    {
        //stop moving
        //replace timer with roar animation
        investigating = false;
        yield return new WaitForSeconds(2f);
        Debug.Log("RIBBIT");
        chasing = true;
    }
    public void Search()
    {
        time = 0;
        searching = true;
        chasing = false;
        //look left
        //look right
    }
}
