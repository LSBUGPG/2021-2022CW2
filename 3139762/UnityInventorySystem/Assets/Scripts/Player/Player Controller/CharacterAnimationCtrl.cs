using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationCtrl : MonoBehaviour
{
    [SerializeField] float crouchSmoothTime = .15f;
    [SerializeField] PlayerStates pStates;

    Animator anim;
    float motionMultiplier = 1;

    float crouch;
    Vector2 crouchBlend;
    Vector2 currAnimBlend;
    Vector2 animVelocity;

    int speedID, jumpID, fallingID, groundedID, motionMulID, crouchID, equipID, unequipID, equippedID, armedStateID, fireID;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        speedID = Animator.StringToHash("Speed");
        jumpID = Animator.StringToHash("Jump");
        fallingID = Animator.StringToHash("Falling");
        groundedID = Animator.StringToHash("Grounded");
        motionMulID = Animator.StringToHash("MotionMultiplier");
        crouchID = Animator.StringToHash("Crouch");
        equipID = Animator.StringToHash("Equip");
        unequipID = Animator.StringToHash("UnEquip");
        equippedID = Animator.StringToHash("Equipped");
        armedStateID = Animator.StringToHash("ArmedState");
        fireID = Animator.StringToHash("Fire");
        anim.SetFloat(motionMulID, motionMultiplier);

        pStates.OnArmedStateSwitch += () => { SwitchArmedState(); };
    }
    private void Update()
    {
    }
    public void SetSpeed(float speedVal)
    {
        anim.SetFloat(speedID, speedVal);
    }
    public void Jump()
    {
        anim.SetTrigger(jumpID);
    }
    public void SetCrouch(float crouchVal)
    {
        anim.SetFloat(crouchID, crouchVal);
        //crouch = crouchVal;
    }
    public void SetFalling(bool falling)
    {
        anim.SetBool(fallingID, falling);
    }
    public void SetGrounded(bool grounded)
    {
        anim.SetBool(groundedID, grounded);
    }
    public void Equip(bool equipped)
    {
        if(equipped) { anim.SetTrigger(equipID); }
        else { anim.SetTrigger(unequipID); }
    }

    public void SwitchEquip()
    {

    }
    public void SwitchArmedState()
    {
        Debug.Log("Switching anim armed state");
        switch (pStates.armedState)
        {
            case PlayerStates.ArmedStates.Unarmed:
                anim.SetFloat(armedStateID, 0);
                break;
            case PlayerStates.ArmedStates.Gadget:
                anim.SetFloat(armedStateID, 1);
                break;
            case PlayerStates.ArmedStates.Melee:
                anim.SetFloat(armedStateID, 1);
                Debug.Log("Anim Melee State");
                break;
            case PlayerStates.ArmedStates.Sword:
                anim.SetFloat(armedStateID, 1);
                break;
            case PlayerStates.ArmedStates.Pistol:
                anim.SetFloat(armedStateID, 2);
                break;
            case PlayerStates.ArmedStates.Rifle:
                anim.SetFloat(armedStateID, 3);
                break;
        }
    }
}
