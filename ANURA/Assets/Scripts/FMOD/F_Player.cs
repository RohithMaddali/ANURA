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
    private F_Music music;
    private bool played;
    public LayerMask lm;
    public float[] values = new float[3];
    private float material;
    public EventInstance footsteps;
    private EventDescription ambDescription;
    private PARAMETER_DESCRIPTION[] pDS = new PARAMETER_DESCRIPTION[3];
    public static PARAMETER_ID[] pIDS = new PARAMETER_ID[3];
    private void Start()
    {
        GetParameters();
        InvokeRepeating("WalkingFootsteps",0,walkingSpeed);
        playerMovement = GetComponent<PlayerMovement>();
        music = GetComponent<F_Music>();
        F_AmbientMusic.ambientMusic.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }
    private void Update()
    {
        MaterialCheck();
    }
    void GetParameters()
    {
        ambDescription = RuntimeManager.GetEventDescription("event:/Player/P_Footsteps");
        ambDescription.getParameterDescriptionByName("ReverbSmall", out pDS[0]);
        ambDescription.getParameterDescriptionByName("ReverbMedium", out pDS[1]);
        ambDescription.getParameterDescriptionByName("ReverbBig", out pDS[2]);

        for (int i = 0; i < pDS.Length; i++)
        {
           pIDS[i] = pDS[i].id;
        }
    }
    void WalkingFootsteps()
    {
        if (playerMovement.isMoving == true)
        {
            footsteps = RuntimeManager.CreateInstance("event:/Player/P_Footsteps");
            footsteps.setParameterByName("Material", material, false);
            footsteps.setParametersByIDs(pIDS, F_ParameterSwitcher.reverbValues, 3, false);
            footsteps.start();
            footsteps.release();
        }
    }
    void MaterialCheck()
    {
        float dist = 4f;
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, dist, lm);
        Debug.DrawRay(transform.position, Vector3.down * dist, Color.red);

        if (hit.collider != null)
        {
            switch (hit.collider.tag)
            {
                case "Concrete":
                    material = 0;
                    Debug.Log("Concrete");
                    break;
                case "Water":
                    material = 1;
                    break;
                default:
                    material = 0;
                    break;
            }
        }
    }
}
