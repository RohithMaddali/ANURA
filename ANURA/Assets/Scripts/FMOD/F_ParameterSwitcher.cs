using UnityEngine;

public class F_ParameterSwitcher : MonoBehaviour
{
    [SerializeField]
    private float runningWater;
    [SerializeField]
    private float wind;
    [SerializeField]
    private float stingers;
    [SerializeField]
    private float waterDrops;
    [SerializeField] 
    private bool onExitSetDefault;
    [SerializeField]
    private float reverbSmall;
    [SerializeField]
    private float reverbMedium;
    [SerializeField]
    private float reverbBig;
    private F_Player playerAudio;
    private float [] values = new float[5];
    public static float [] reverbValues = new float[3];
    private void Start()
    {
        values[0] = runningWater;
        values[1] = wind;
        values[3] = stingers;
        values[4] = waterDrops;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player1"))
        {
                F_Ambience.amb.setParametersByIDs(F_Ambience.parameterIds, values, 4, false);
                reverbValues[0] = reverbSmall;
                reverbValues[1] = reverbMedium;
                reverbValues[2] = reverbBig;
                F_ToadAnimations.toadValues[0] = reverbSmall;
                F_ToadAnimations.toadValues[1] = reverbMedium;
                F_ToadAnimations.toadValues[3] = reverbBig;
        }
    }
}
