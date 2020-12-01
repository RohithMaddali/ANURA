
using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class F_Occlusion : MonoBehaviour
{
    [SerializeField]
    private float OcclusionRadius = 30f;
    private EventInstance frogGrowl;
    private Vector3 objPosition;
    [SerializeField] private LayerMask lm;
    private RaycastHit hit;
    Transform player;
    void Start()
    {
        player = GameObject.Find("First Person Player").GetComponent<Transform>();
        frogGrowl = RuntimeManager.CreateInstance("event:/Enemy/EnemySounds");
        RuntimeManager.AttachInstanceToGameObject(frogGrowl, transform, GetComponent<Rigidbody>());
        frogGrowl.start();
    }
    private void OnDrawGizmosSelected() //Visual Radius For Occlusion & Music.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, OcclusionRadius);
    }
    
    private void FixedUpdate()
    {
        if (!(player is null))
        {
            float distance = Vector3.Distance(transform.position, player.position); //Distance Between player and sound source
            if (distance <= OcclusionRadius)
            {
                Occlusion();
                Lowpass();
            }
            else
            {
                frogGrowl.setParameterByName("LowPass", 0, false);
            }
        }
    }
    void Occlusion() //Raycast From sound Source to Player
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        Vector3 directionToFace = player.transform.position - transform.position;
        Physics.Raycast(transform.position, directionToFace, out hit, dist, lm);
        Debug.DrawRay(transform.position, directionToFace, Color.red);
    }
    void Lowpass() //Occludes Sound Source
    {
        if (hit.collider)
        {
            if (hit.collider.gameObject.CompareTag("Wall"))
            {
                Debug.Log("wall");
                frogGrowl.setParameterByName("LowPass", 1, true);
            }
            else
            {
                Debug.Log("No wall");
                frogGrowl.setParameterByName("LowPass", 0, true);
            }
        }
    }

    private void OnDestroy()
    {
        frogGrowl.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        frogGrowl.release();
    }
}
