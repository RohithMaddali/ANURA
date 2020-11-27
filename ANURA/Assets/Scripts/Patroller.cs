using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class Patroller : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentPoint;
    public Transform[] patrolPoints;
    private Transform temp;

    public float moveSpeed;
    GameObject player;
    public Vector3 lastKnownPos;
    /*public bool patrolling = true;
    public bool investigating;
    public bool chasing;
    public bool searching;*/
    public float time;
    public float searchtimer = 10;
    public NavMeshAgent agent;
    GameManager gm;
    
    
    
    public enum Behaviour
    {
        patrolling,
        investigating,
        chasing,
        searching
    }
    public Behaviour action;

    void Start()
    {
        for(int i = 0; i < patrolPoints.Length; i++)
        {
            int rnd = Random.Range(0, patrolPoints.Length);
            temp = patrolPoints[rnd];
            patrolPoints[rnd] = patrolPoints[i];
            patrolPoints[i] = temp;
        }
        transform.position = patrolPoints[0].position;
        player = GameObject.FindGameObjectWithTag("Player");
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (action)
        {
            case Behaviour.patrolling:
                if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.6f)
                {
                    currentPoint = (currentPoint + 1) % patrolPoints.Length;
                    NavMeshPath navMeshPath = new NavMeshPath();
                    agent.CalculatePath(patrolPoints[currentPoint].position, navMeshPath);
                    if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                    {
                        agent.SetDestination(patrolPoints[currentPoint].position);
                        //Debug.Log("Toad moving to " + patrolPoints[currentPoint]);
                    }
                    else
                    {
                        Debug.Log("Can't find route to " + patrolPoints[currentPoint] + " returning to start");
                        currentPoint = 0;
                        agent.SetDestination(patrolPoints[currentPoint].position);
                    }
                }
                else agent.SetDestination(patrolPoints[currentPoint].position);
                break;

            case Behaviour.investigating:
                agent.SetDestination(lastKnownPos);

                //Debug.Log("a toad heard that");
                if (Vector3.Distance(transform.position, lastKnownPos) < 1f)
                {
                    RestartTime();
                    action = Behaviour.searching;
                }
                break;

            case Behaviour.searching:
                time += Time.deltaTime;
                //walk around a bit
                if (time >= searchtimer)
                {
                    time = 0;
                    action = Behaviour.patrolling;
                    
                }
                break;

            case Behaviour.chasing:
                agent.SetDestination(player.transform.position);
                break;
        }





        /*if (patrolling)
        {
            //transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, patrolPoints[currentPoint].position) < 0.6f)
            {
                currentPoint = (currentPoint + 1) % patrolPoints.Length;
                NavMeshPath navMeshPath = new NavMeshPath();
                agent.CalculatePath(patrolPoints[currentPoint].position, navMeshPath);
                if (navMeshPath.status == NavMeshPathStatus.PathComplete)
                {
                    agent.SetDestination(patrolPoints[currentPoint].position);
                    Debug.Log("Toad moving to " + patrolPoints[currentPoint]);
                }
                else
                {
                    Debug.Log("Can't find route to " + patrolPoints[currentPoint] + " returning to start");
                    currentPoint = 0;
                    agent.SetDestination(patrolPoints[currentPoint].position);
                }
            }
            
        }

        if (investigating)
        {
            //Quaternion rotTarget = Quaternion.LookRotation(lastKnownPos - transform.position);
            //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotTarget, 40 * Time.deltaTime);

            //transform.position = Vector3.MoveTowards(transform.position, lastKnownPos, moveSpeed * Time.deltaTime);
            agent.SetDestination(lastKnownPos);
            
            Debug.Log("a toad heard that");
            if(transform.position == lastKnownPos)
            {
                investigating = false;
                RestartTime();
            }
        }

        if (chasing)
        {
            //transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
            agent.SetDestination(player.transform.position);
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
                //walk around a bit
            }
        }*/
    }
    IEnumerator RoarAndChase()
    {
        //stop moving
        //replace timer with roar animation
        //searching = false;
        //investigating = false;
        //patrolling = false;
        Debug.Log("RIBBIT");
        ToadSawPlayer();
        yield return new WaitForSeconds(.75f);
        action = Behaviour.chasing;
        yield return new WaitForSeconds(3f);
        lastKnownPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        action = Behaviour.investigating;
    }
    public void RestartTime()
    {
        time = 0;
        //searching = true;
        //chasing = false;

        //look left
        //look right
    }

    public void ToadSawPlayer()
    {

        Analytics.CustomEvent("PlayerSpotted", new Dictionary<string, object>
        {
            {"toad", gameObject.name },
            {"room", gameObject.transform.parent.gameObject.name }
        });
    }
}
