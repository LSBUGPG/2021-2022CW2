using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EquipSystem : MonoBehaviour
{
    [SerializeField] InventorySO equipment;
    [SerializeField] Transform equipPoint;
    [SerializeField] PlayerStates pStates;

    [SerializeField] InputAction toolbarInput;
    [SerializeField] CharacterAnimationCtrl cAnim;
    public bool selfInput = true;

    int currEquipSlot = -1;

    private void OnEnable()
    {
        if(selfInput) { 
            toolbarInput.Enable();
            toolbarInput.performed += context => { Debug.Log("Toolbar input"); var input = context.ReadValue<float>(); if (input > 0) { NextEquip(); } if (input < 0) { PreviousEquip(); } };
        }
    }
    private void OnDisable()
    {
        toolbarInput.Disable();
    }
    public void NextEquip()
    {
        Debug.Log("Next Weapon");
        InvSlot[] equipSlots = equipment.contents.invSlots;
        for (int i = currEquipSlot >= 0 ? currEquipSlot : 0; i < equipment.contents.invSlots.Length; i++)
        {
            if (equipSlots[i].ID > -1) { pStates.armedState = PlayerStates.ArmedStates.Unarmed; EquipItem(i); return; }
        }
    }
    public void PreviousEquip()
    {
        Debug.Log("Previous Weapon");
        InvSlot[] equipSlots = equipment.contents.invSlots;
        for (int i = currEquipSlot; i >= 0; i--)
        {
            if (equipSlots[i].ID > -1) { EquipItem(i); return; }
        }
    }

    public void EquipItem(int equipIndex)
    {
        InvSlot[] equipSlots = equipment.contents.invSlots;

        if (equipIndex > equipSlots.Length - 1 || equipIndex < 0) { pStates.armedState = PlayerStates.ArmedStates.Unarmed; return; }
        
        if (currEquipSlot == equipIndex && currEquipSlot != -1 || equipment.contents.invSlots[equipIndex].item == null) { foreach (Transform child in equipPoint) { Destroy(child.gameObject); } currEquipSlot = -1; return; }
           
        currEquipSlot = equipIndex;

        foreach (Transform child in equipPoint)
        {
            Destroy(child.gameObject);
        }
        GameObject prefab = GetItemPrefab(equipSlots[equipIndex].item.Id) != null ? GetItemPrefab(equipSlots[equipIndex].item.Id) : equipment.db.defaultItem.prefab;
        GameObject equipGO = Instantiate(prefab, equipPoint);
        if (currEquipSlot > -1) { cAnim.Equip(true); } else { cAnim.Equip(false); }

        if(equipment.db.GetItemById(equipSlots[equipIndex].item.Id).type == ItemTypes.Weapon || equipment.db.GetItemById(equipSlots[equipIndex].item.Id).type == ItemTypes.Gadget) { pStates.armedState = PlayerStates.ArmedStates.Melee; } else { pStates.armedState = PlayerStates.ArmedStates.Unarmed; }
    }
    public GameObject GetItemPrefab(int itemID)
    {
        return equipment.db.GetItemById(itemID).prefab;
    }
    private void Update()
    {
        UpdateEquip();
    }
    void UpdateEquip()
    {
        if (currEquipSlot >= 0 && equipment.contents.invSlots[currEquipSlot].ID < 0)
        {
            foreach (Transform child in equipPoint)
            {
                Destroy(child.gameObject);
            }
            currEquipSlot = -1;
        }
        
    }
}
