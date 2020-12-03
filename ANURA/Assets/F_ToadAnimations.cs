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
   private float material;
   [SerializeField]
   private LayerMask lm;
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

   private void Update()
   {
      MaterialCheck();
   }
   public void ToadHop()
   {
      EventInstance toadHop = RuntimeManager.CreateInstance("event:/Enemy/E_Footsteps");
      RuntimeManager.AttachInstanceToGameObject(toadHop,transform, GetComponent<Rigidbody>());
      toadHop.setParametersByIDs(parameterIdsToad, toadValues, 3, false);
      toadHop.setParameterByName("Material", material, false);
      toadHop.start();
      toadHop.release();
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
