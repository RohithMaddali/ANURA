using UnityEngine;
using FMOD.Studio;
using FMODUnity;

public class F_Player : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField]
    private float walkingSpeed = 1;
    [SerializeField]
    private float walkingBackwardsSpeed = 1;
    
    private void Start()
    {
        InvokeRepeating("WalkingFootsteps",0,walkingSpeed);
        playerMovement = GetComponent<PlayerMovement>();
    }
    void WalkingFootsteps()
    {
        if (playerMovement.isMoving == true)
        {
            RuntimeManager.PlayOneShot("event:/Player/P_Footsteps",default);
        }
    }
}
