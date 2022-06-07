using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StaticInterface : InvInterface
{
    public GameObject[] slots;
    public override void SetupSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InvSlot>();
        for (int i = 0; i < inv.contents.invSlots.Length; i++)
        {
            var obj = slots[i];
            ExtendedButton slotExBTN = slots[i].GetComponent<ExtendedButton>();

            slotExBTN.SetPointerActions((/*OnEnter*/) => {OnEnter(obj);}, (/*OnExit*/) => {OnExit(obj);});
            slotExBTN.SetDragActions((/*OnDrag*/) => { OnDrag(obj); },(/*OnDragStart*/) => { OnDragStart(obj); },(/*OnDragEnd*/) => { OnDragEnd(obj); }, ExtendedButton.PointerBTNTypes.Left);
            itemsDisplayed.Add(obj, inv.contents.invSlots[i]);
        }
    }
}
