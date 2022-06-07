using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonInput : MonoBehaviour
{
    public bool enableInputAtStart = true;
    PlayerInput pInput;
    void Awake()
    {
        pInput = new PlayerInput();
    }
    private void Start()
    {
        if(enableInputAtStart) Enable();
    }

    public void Enable()
    {
        pInput.PlayerMovement.Enable();
    }
    public void Disable()
    {
        pInput.PlayerMovement.Disable();
    }
    public Vector2 LookDir()
    {
        return pInput.PlayerMovement.Look.ReadValue<Vector2>();
    }
    public Vector2 MovementDir()
    {
        Vector2 inputVec = pInput.PlayerMovement.Movement.ReadValue<Vector2>();
        return inputVec.normalized;
    }
    public bool JumpPressed()
    {
        return pInput.PlayerMovement.Jump.ReadValue<float>() > .5f ? true : false;
    }
    public bool CrouchPressed()
    {
        return pInput.PlayerMovement.Crouch.ReadValue<float>() > .5f ? true : false;
    }
    public bool SprintPressed()
    {
        return pInput.PlayerMovement.Sprint.ReadValue<float>() > .5f ? true : false;
    }
    public bool InteractPressed()
    {
        return pInput.PlayerMovement.Interact.ReadValue<float>() > .5f ? true : false;
    }
    public bool DeployDrone()
    {
        return pInput.PlayerMovement.DeployDrone.ReadValue<float>() > .5f ? true : false;
    }
    public bool PrimaryFire()
    {
        return pInput.PlayerMovement.PrimaryFire.ReadValue<float>() > .5f ? true : false;
    }
    public bool SecondaryFire()
    {
        return pInput.PlayerMovement.SecondaryFire.ReadValue<float>() > .5f ? true : false;
    }
    public bool InvPressed()
    {
        return pInput.PlayerMovement.Inventory.ReadValue<float>() > .5f ? true : false;
    }
}
