using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStates : MonoBehaviour
{
    public enum MotionStates
    {
        Idle,
        Walking,
        Running
    }
    MotionStates currMotionState = MotionStates.Idle;
    public MotionStates motionState { get { return currMotionState; } set { if (value != currMotionState) { MotionStateSwitch(); } currMotionState = value;} }
    public UnityAction OnMotionStateSwitch;
    void MotionStateSwitch()
    {
        OnMotionStateSwitch?.Invoke();
    }
    public enum StanceStates
    {
        Crouching,
        Standing,
        Jumping,
        Floating
    }
    StanceStates currStanceState = StanceStates.Standing;
    public StanceStates stanceState { get { return currStanceState; } set { if (value != currStanceState) { StanceStateSwitch(); } currStanceState = value; } }
    public UnityAction OnStanceStateSwitch;
    void StanceStateSwitch()
    {
        OnStanceStateSwitch?.Invoke();
    }
    public enum ArmedStates
    {
        Unarmed,
        Gadget,
        Melee,
        Sword,
        Pistol,
        Rifle
    }
    ArmedStates currArmedState = ArmedStates.Unarmed;
    public ArmedStates armedState { get { return currArmedState; } set { if (value != currArmedState) { currArmedState = value; ArmedStateSwitch(); }} }
    public UnityAction OnArmedStateSwitch;
    void ArmedStateSwitch()
    {
        OnArmedStateSwitch?.Invoke();
        Debug.Log("Armed State Switched");
    }
    public enum EquipStates
    {
        Equipped,
        Unequipped
    }
    EquipStates currEquipState = EquipStates.Unequipped;
    public EquipStates equipState { get { return currEquipState; } set { if (value != currEquipState) { EquipStateSwitch(); } currEquipState = value; } }
    public UnityAction OnEquipStateSwitch;
    void EquipStateSwitch()
    {
        OnEquipStateSwitch?.Invoke();
    }
}
