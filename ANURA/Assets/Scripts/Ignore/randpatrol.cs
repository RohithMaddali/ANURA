using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randpatrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    public float maxY;
    public float minY;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;

        moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ), Random.Range(minY, maxY)); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                moveSpot.position = new Vector3(Random.Range(minX, maxX), Random.Range(minZ, maxZ));
                waitTime = startWaitTime;
            }

            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
