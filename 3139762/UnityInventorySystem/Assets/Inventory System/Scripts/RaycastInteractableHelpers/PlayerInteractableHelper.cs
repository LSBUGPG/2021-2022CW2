using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractableHelper : MonoBehaviour
{
    PlayerRCInteract pInteract;
    PlayerInv pInv;
    [SerializeField] InvInterface exInvUI;
    InteractableObject _lastInteractable;
    InteractableObject lastInteractable { get { return _lastInteractable; } set { _lastInteractable = value; SetGroundObjInteract(); } }

    private void Awake()
    {
        pInv = GetComponent<PlayerInv>();
        pInteract = GetComponent<PlayerRCInteract>();
    }
    private void Update()
    {
        if (pInteract.currInteractable != lastInteractable) lastInteractable = pInteract.currInteractable;
    }
    void SetGroundObjInteract()
    {
        if (pInteract.currInteractable == null) return;
        GroundItem gItem = pInteract.currInteractable.GetComponent<GroundItem>();
        ExternalInv exInv = pInteract.currInteractable.GetComponent<ExternalInv>();
        InteractableObject objInteract = null;
        if (gItem)
        {
            Debug.Log("Setting item pickup action");
            objInteract = pInteract.currInteractable;
            objInteract.mainInteract = () => { if (pInv.GetInventory().IsInvFull()) { Debug.Log("Inventory is full!"); } else { Debug.Log("Picking up item"); pInv.GetInventory().AddItem(gItem.GetContents()); Destroy(gItem.gameObject); } };
        }
        if (exInv)
        {
            Debug.Log("Setting external inv action");
            objInteract = pInteract.currInteractable;
            objInteract.mainInteract = () => { exInvUI.OpenWithInventory(exInv.GetInv(), true); };
        }
    }
}
