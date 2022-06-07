using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractableHelper : MonoBehaviour
{
    InteractableObject iObj;
    GroundItem gItem;
    void Start()
    {
        iObj = GetComponent<InteractableObject>();
        gItem = GetComponent<GroundItem>();
    }
    void Update()
    {
        SetInteractInfo();
    }
    bool done = false;
    void SetInteractInfo()
    {
        if (done) return;
        if (!gItem.setupDone) return;
        if (gItem.GetContents() == null) return;
        else
        {
            InvSlot contents = gItem.GetContents();
            iObj.interactInfo.interactAction = "Pick up";
            iObj.interactInfo.interactDescription = contents.item.name + " x" + contents.amount;
            done = true;
        }
    }
}
