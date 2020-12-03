using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class F_ToadAnimations : MonoBehaviour
{
   private EventDescription ambDescription;
   private PARAMETER_DESCRIPTION[] pDs = new PARAMETER_DESCRIPTION[4];
   public static PARAMETER_ID[] parameterIdsToad = new PARAMETER_ID[4];
   public static float[] toadValues = new float[3];


   private void Start()
   {
      ambDescription = RuntimeManager.GetEventDescription("event:/Enemy/E_Footsteps");
      ambDescription.getParameterDescriptionByName("ReverbSmall", out pDs[0]);
      ambDescription.getParameterDescriptionByName("ReverbMedium", out pDs[0]);
      ambDescription.getParameterDescriptionByName("ReverbBig", out pDs[0]);

      for (int i = 0; i < pDs.Length; i++)
      {
         parameterIdsToad[i] = pDs[i].id;
      }
   }

   public void ToadHop()
   {
      EventInstance toadHop = RuntimeManager.CreateInstance("event:/Enemy/E_Footsteps");
      RuntimeManager.AttachInstanceToGameObject(toadHop,transform, GetComponent<Rigidbody>());
      toadHop.setParametersByIDs(parameterIdsToad, toadValues, 3, false);
      toadHop.start();
      toadHop.release();
   }
}
