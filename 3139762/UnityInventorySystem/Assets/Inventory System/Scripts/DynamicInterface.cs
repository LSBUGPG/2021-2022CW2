using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicInterface : InvInterface
{
    [SerializeField] GameObject itemSlotTemplate;
    [SerializeField] float slotSize = 125;
    [SerializeField] int maxHorizontalSlots = 6;
    public override void SetupSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InvSlot>();
        int x = 0, y = 0;
        for (int i = 0; i < inv.contents.invSlots.Length; i++)
        {
            var obj = Instantiate(itemSlotTemplate, itemSlotContainer);
            ExtendedButton slotExBTN = obj.GetComponent<ExtendedButton>();

            slotExBTN.SetPointerActions((/*OnEnter*/) => {OnEnter(obj); }, (/*OnExit*/) => { OnExit(obj); });
            slotExBTN.SetDragActions((/*OnDrag*/) => { OnDrag(obj); }, (/*OnDragStart*/) => { OnDragStart(obj); }, (/*OnDragEnd*/) => { OnDragEnd(obj); }, ExtendedButton.PointerBTNTypes.Left);
            itemsDisplayed.Add(obj, inv.contents.invSlots[i]);

            var rt = obj.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(x * slotSize, y * slotSize);
            x++;
            if (x >= maxHorizontalSlots)
            {
                x = 0;
                if(i < inv.contents.invSlots.Length-1) y--;
            }
            RectTransform cRT = itemSlotContainer.GetComponent<RectTransform>();
            cRT.sizeDelta = new Vector2(maxHorizontalSlots * slotSize, (Mathf.Abs(y)+1) * slotSize);
        }
    }
}
