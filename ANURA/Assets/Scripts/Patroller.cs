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
    public bool patrolling = true;
    public bool investigating;
    public bool chasing;
    
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

        if (chasing)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
        
    }
    IEnumerator RoarAndChase()
    {
        //stop moving
        //replace timer with roar animation
        yield return new WaitForSeconds(2f);
        chasing = true;
    }
}
