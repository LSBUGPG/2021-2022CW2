using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[System.Serializable]
public class WheelItem
{
    public string itemTitle;
    public string description;
    public Sprite itemIMG;
    public Color itemIMGColour;
    public string requirement;
    public Action itemAction;
    public bool selectable;
    public WheelItem(string _title, string _desc, Sprite _IMG, Color _IMGColour, string _requirement, Action _action, bool _selectable)
    {
        itemTitle = _title;
        description = _desc;
        itemIMG = _IMG;
        itemIMGColour = _IMGColour;
        requirement = _requirement;
        itemAction = _action;
        selectable = _selectable;
    }
    public WheelItem(string _title, string _desc, Sprite _IMG, string _requirement, Action _action, bool _selectable)
    {
        itemTitle = _title;
        description = _desc;
        itemIMG = _IMG;
        requirement = _requirement;
        itemAction = _action;
        selectable = _selectable;
    }
    public WheelItem(string _title, string _desc, Sprite _IMG, Color _IMGColour, Action _action)
    {
        itemTitle = _title;
        description = _desc;
        itemIMG = _IMG;
        itemIMGColour = _IMGColour;
        requirement = null;
        itemAction = _action;
        selectable = true;
    }
    public WheelItem(string _title, string _desc, Sprite _IMG, Action _action)
    {
        itemTitle = _title;
        description = _desc;
        itemIMG = _IMG;
        requirement = null;
        itemAction = _action;
        selectable = true;
    }
}
public class SelectWheelCtrl : MonoBehaviour
{
    [SerializeField] InputAction selectDirInput, selectInput, closeInput;
    [SerializeField] RectTransform pointer;
    [SerializeField] float pointerSmoothTime = .075f;
    [SerializeField] float selectionGap = 15f;

    [SerializeField] Transform menu;
    [SerializeField] Transform itemTemplate;
    [SerializeField] Transform itemsParent;

    [SerializeField] Sprite defaultItemIMG;

    [SerializeField] Text itemName;
    [SerializeField] Text itemDescription;
    [SerializeField] Text itemRequirement;
    [SerializeField] Color requirementFulfilled = Color.green, requirementUnfulfilled = Color.red;

    Vector2 inputDir;
    Vector2 pointerVel;


    WheelItemUI currHoveredItem;
    Action currSelectAction;

    WheelItemUI checkItemAnim;
    bool generated = false;
    private void Start()
    {
        selectInput.performed += context => { if (context.phase == InputActionPhase.Performed) SelectItem(); };
    }
    private void Update()
    {
        inputDir = selectDirInput.ReadValue<Vector2>().normalized;
        if (inputDir.magnitude != 0) pointer.up = Vector2.SmoothDamp(pointer.up, inputDir, ref pointerVel, pointerSmoothTime);
        if(generated) FindHoveredItem();
        if (closeInput.ReadValue<float>() > .5f) CloseMenu(false);
    }
    public void OpenSelectWheel(List<WheelItem> wheelItems)
    {
        foreach (Transform item in itemsParent)
        {
            Destroy(item.gameObject);
        }
        selectInput.Enable();
        selectDirInput.Enable();
        closeInput.Enable();

        menu.gameObject.SetActive(true);

        generated = GenerateItems(wheelItems);
    }
    bool GenerateItems(List<WheelItem> wheelItems)
    {
        int itemAmount = wheelItems.Count;
        float itemAngleIncrement = 360 / itemAmount;
        int index = 0;
        WheelItemUI newItemCtrl;
        foreach (WheelItem item in wheelItems)
        {
            Transform newItem = Instantiate(itemTemplate, itemsParent);
            newItemCtrl = newItem.GetComponent<WheelItemUI>();
            newItem.eulerAngles = new Vector3(0, 0, index * itemAngleIncrement);
            newItemCtrl.Setup(item);
            newItem.gameObject.SetActive(true);
            index++;
        }
        itemTemplate.gameObject.SetActive(false);
        return true;
    }
    void FindHoveredItem()
    {
        WheelItemUI itemCtrl = null;
        foreach (Transform child in itemsParent)
        {
            if (child == null) return;
            itemCtrl = child.GetComponent<WheelItemUI>();
            if (child.eulerAngles.z - selectionGap <= pointer.eulerAngles.z && pointer.eulerAngles.z <= child.eulerAngles.z + selectionGap)
            {
                currHoveredItem = itemCtrl;
                itemCtrl.SetState(WheelItemUI.ItemStates.Hover);
                itemName.text = currHoveredItem.thisItem.itemTitle;
                itemDescription.text = currHoveredItem.thisItem.description;
                itemRequirement.text = currHoveredItem.thisItem.requirement;
                itemRequirement.color = currHoveredItem.thisItem.selectable ? requirementFulfilled : requirementUnfulfilled;
                currSelectAction = currHoveredItem.thisItem.selectable ? currHoveredItem.thisItem.itemAction : null;
            }
            if(currHoveredItem != null) if(child != currHoveredItem.transform && itemCtrl != null) { itemCtrl.SetState(WheelItemUI.ItemStates.Normal); }
        }
    }
    void SelectItem()
    {
        if (currSelectAction == null) return;
        currSelectAction?.Invoke(); 
        currSelectAction = null;

        WheelItemUI itemCtrl;
        foreach (Transform child in itemsParent)
        {
            itemCtrl = child.GetComponent<WheelItemUI>();
            if (currHoveredItem == itemCtrl) { checkItemAnim = itemCtrl; itemCtrl.SetState(WheelItemUI.ItemStates.Selected); }
            else { itemCtrl.SetState(WheelItemUI.ItemStates.Close); }
        }
        StartCoroutine(WaitToClose());
    }
    public void CloseMenu(bool cancelAnim)
    {
        if (cancelAnim) {
            CloseCtrl();
        }
        
        WheelItemUI itemCtrl;
        foreach (Transform child in itemsParent)
        {
            itemCtrl = child.GetComponent<WheelItemUI>();
            itemCtrl.SetState(WheelItemUI.ItemStates.Close);
            checkItemAnim = itemCtrl;
        }
        StartCoroutine(WaitToClose());
    }
    void CloseCtrl()
    {
        currHoveredItem = null;
        foreach (Transform item in itemsParent)
        {
            Destroy(item.gameObject);
        }
        menu.gameObject.SetActive(false);
        generated = false;
        selectInput.Disable();
        selectDirInput.Disable();
        closeInput.Disable();
    }
    IEnumerator WaitToClose()
    {
        while (!checkItemAnim.animDone)
        {
            yield return null;
        }
        CloseCtrl();
    }
}
