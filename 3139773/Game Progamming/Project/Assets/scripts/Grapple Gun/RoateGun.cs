using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoateGun : MonoBehaviour
{



    public GrappleGun grappling;
    private Quaternion desiredRotation;
    private float rotationspeed = 5f;


    

    // Update is called once per frame
    void Update()
    {
        if (!grappling.IsGrappling())
        {
            desiredRotation = transform.parent.rotation;
        }
        else
        {
            desiredRotation = Quaternion.LookRotation(grappling.GetGrapplePoint() - transform.position);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationspeed);
    }

   
}
