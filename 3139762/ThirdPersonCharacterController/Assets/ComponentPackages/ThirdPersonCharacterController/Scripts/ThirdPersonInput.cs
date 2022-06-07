using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonInput : MonoBehaviour
{
    Controls pInput;
    void Awake()
    {
        pInput = new Controls();
    }
    private void Start()
    {
        pInput.Player.Enable();
    }

    public void Enable()
    {
        pInput.Player.Enable();
    }
    public void Disable()
    {
        pInput.Player.Disable();
    }
    public Vector2 LookDir()
    {
        return pInput.Player.Look.ReadValue<Vector2>();
    }
    public Vector2 MovementDir()
    {
        Vector2 inputVec = pInput.Player.Movement.ReadValue<Vector2>();
        return inputVec.normalized;
    }
    public bool JumpPressed()
    {
        return pInput.Player.Jump.ReadValue<float>() > .5f ? true : false;
    }
    public bool SprintPressed()
    {
        return pInput.Player.Sprint.ReadValue<float>() > .5f ? true : false;
    }
}
