using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelItemUI : MonoBehaviour
{
    public enum ItemStates{
        Normal,
        Hover,
        Selected,
        Open,
        Close
    }
    [SerializeField] Image itemIMGElement;
    Color itemDefaultColour;
    [SerializeField] Transform slotIMG;
    [SerializeField] Image enabledIMG;
    [SerializeField] Transform gfxParent;
    Animator anim;
    [SerializeField] string hoverAnimBoolName = "Hover", selectedAnimTriggerName = "Selected", openAnimTriggerName = "Open", closeAnimTriggerName = "Close";
    [SerializeField] Sprite defaultItemIMG;
    public bool animDone = false;
    int hoverID, selectedID, openID, closeID;
    public WheelItem thisItem;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        hoverID = Animator.StringToHash(hoverAnimBoolName);
        selectedID = Animator.StringToHash(selectedAnimTriggerName);
        openID = Animator.StringToHash(openAnimTriggerName);
        closeID = Animator.StringToHash(closeAnimTriggerName);

        itemDefaultColour = itemIMGElement.color;
    }
    public void Setup(WheelItem item)
    {
        thisItem = item;
        itemIMGElement.sprite = item.itemIMG == null ? defaultItemIMG : item.itemIMG;
        itemIMGElement.color = item.itemIMGColour.a > 0 ? item.itemIMGColour : itemDefaultColour;
        if (thisItem.selectable) enabledIMG.enabled = false;
        foreach (Transform child in gfxParent)
        {
            child.eulerAngles = Vector3.zero;
        }
    }
    public void SetState(ItemStates state)
    {
        switch (state)
        {
            case ItemStates.Normal: 
                anim.SetBool(hoverID, false);
                break;
            case ItemStates.Hover:
                anim.SetBool(hoverID, true);
                break;
            case ItemStates.Selected:
                anim.SetTrigger(selectedID);
                break;
            case ItemStates.Open:
                anim.SetTrigger(openID);
                break;
            case ItemStates.Close:
                anim.SetTrigger(closeID);
                break;
        }
    }
}
