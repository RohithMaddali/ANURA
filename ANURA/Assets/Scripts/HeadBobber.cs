using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBobber : MonoBehaviour
{
 
    public float timer = 0.0f;
    public float bobbingSpeed = 0.05f;
    public float bobbingAmount = 0.05f;
    public float midpoint = 1f;
  
    
    
    public float waveslice = 0.0f;
    void Update () {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
  
        Vector3 mover = transform.localPosition; 
  
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
            timer = 0.0f;
        }
        else {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2) {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0) {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            mover.y = midpoint + translateChange;
        }
        else {
            mover.y = midpoint;
        }
  
        transform.localPosition = mover;
    }
}