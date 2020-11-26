using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Analytics;


public class FOVDetection : MonoBehaviour
{

    public Transform enemy;
    public Transform player;
    public float maxAngle;
    public float maxRadius;
    public float speed = 3f;

    private bool isInFov = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnDrawGizmos()
    {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, maxRadius);

            Vector3 fovLine1 = Quaternion.AngleAxis(maxAngle, transform.up) * transform.forward * maxRadius;
            Vector3 fovLine2 = Quaternion.AngleAxis(-maxAngle, transform.up) * transform.forward * maxRadius;

            Gizmos.color = Color.blue;
            Gizmos.DrawRay(transform.position, fovLine1);
            Gizmos.DrawRay(transform.position, fovLine2);

            if (!isInFov)
                Gizmos.color = Color.red;
            else
                Gizmos.color = Color.green;
            Gizmos.DrawRay(transform.position, (player.position - transform.position).normalized * maxRadius);

            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, transform.forward * maxRadius);
        


    }

    public static bool inFOV(Transform checkingObject, Transform target, float maxAngle, float maxRadius, Transform enemy, float speed)
    {

        Collider[] overlaps = new Collider[10];
        int count = Physics.OverlapSphereNonAlloc(checkingObject.position, maxRadius, overlaps);

        for (int i = 0; i < count - 1; i++)
        {

            if (overlaps[i] != null)
            {

                if (overlaps[i].transform == target)
                {

                    Vector3 directionBetween = (target.position - checkingObject.position).normalized;
                    directionBetween.y *= 0;

                    float angle = Vector3.Angle(checkingObject.forward, directionBetween);

                    if (angle <= maxAngle)
                    {

                        Ray ray = new Ray(checkingObject.position, target.position - checkingObject.position);
                        RaycastHit hit;

                        if (Physics.Raycast(ray, out hit, maxRadius))
                        {

                            if (hit.transform == target)
                            {
                                //enemy.transform.LookAt(target);
                                

                                Debug.Log("The Toad Sees You!");
                                Quaternion rotTarget = Quaternion.LookRotation(target.position - enemy.position);
                                enemy.transform.rotation = Quaternion.RotateTowards(enemy.transform.rotation, rotTarget, speed * Time.deltaTime);
                                checkingObject.GetComponent<Patroller>().StartCoroutine("RoarAndChase");
                                return true;
                            }
                                
                            
                        }


                    }


                }

            }
            /*else if(overlaps[i] == null && checkingObject.GetComponent<Patroller>().action == Patroller.Behaviour.chasing)
            {
                //target lost
                Debug.Log("the toad lost the player");
                checkingObject.GetComponent<Patroller>().lastKnownPos = GameObject.FindGameObjectWithTag("Player").transform.position;
                //start timer
                checkingObject.GetComponent<Patroller>().action = Patroller.Behaviour.investigating;
                //look around
                //return to patrolling or find target again
            }*/

        }

        return false;
    }

    private void Update()
    {

        isInFov = inFOV(transform, player, maxAngle, maxRadius, enemy, speed);

    }

}