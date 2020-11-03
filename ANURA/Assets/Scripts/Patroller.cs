using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroller : MonoBehaviour
{
    // Start is called before the first frame update
    private int currentPoint;
    public Transform[] patrolPoints;
    public float moveSpeed;
    
    void Start()
    {
        transform.position = patrolPoints[0].position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPoint].position)
        {
            currentPoint = (currentPoint + 1) % patrolPoints.Length;
        }
    }
}
