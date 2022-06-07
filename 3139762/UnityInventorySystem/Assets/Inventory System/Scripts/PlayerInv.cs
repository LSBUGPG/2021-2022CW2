using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInv : MonoBehaviour
{
    [SerializeField] InventorySO inv;
    [SerializeField] Transform dropPoint;
    [SerializeField] InvInterface[] invInterfaces;

    public bool useCursorInputAction = true, useToggleInputAction = true;
    [SerializeField] InputAction toggleInventoryInput, cursorPosInput;

    public MouseItem mouseItem = new MouseItem();
    private void Awake()
    {
        inv.dropP = dropPoint;
    }
    private void OnEnable()
    {
        if (useCursorInputAction)
        {
            cursorPosInput.Enable();
        }
        if (useToggleInputAction)
        {
            toggleInventoryInput.Enable();
            toggleInventoryInput.performed += context => { if (context.phase == InputActionPhase.Performed) foreach (InvInterface ui in invInterfaces) { ui.ToggleInventory(false); } };
        }

    }
    private void OnDisable()
    {
        if (useCursorInputAction)
        {
            cursorPosInput.Disable();
        }
        if (useToggleInputAction)
        {
            toggleInventoryInput.Disable();
            toggleInventoryInput.performed -= context => { if (context.phase == InputActionPhase.Performed) foreach (InvInterface ui in invInterfaces) { ui.ToggleInventory(false); } };
        }

    }
    private void Update()
    {
        //Save load test
        if (Input.GetKeyDown(KeyCode.K))
        {
            inv.Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            inv.Load();
        }
        foreach (InvInterface ui in invInterfaces)
        {
            ui.SetCursorPos(cursorPosInput.ReadValue<Vector2>());
        }
    }
    public InventorySO GetInventory()
    {
        return inv;
    }
    private void OnApplicationQuit()
    {
        inv.Clear();
    }
}

