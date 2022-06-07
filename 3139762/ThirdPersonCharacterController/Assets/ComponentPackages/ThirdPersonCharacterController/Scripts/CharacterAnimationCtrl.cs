using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationCtrl : MonoBehaviour
{
    Animator anim;
    float motionMultiplier = 1;
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.SetFloat("MotionMultiplier", motionMultiplier);
    }
    public void SetSpeed(float speedVal)
    {
        anim.SetFloat("Speed", speedVal);
    }
    public void Jump()
    {
        anim.SetTrigger("Jump");
    }
    public void SetFalling(bool falling)
    {
        anim.SetBool("Falling", falling);
    }
    public void SetGrounded(bool grounded)
    {
        anim.SetBool("Grounded", grounded);
    }
}
