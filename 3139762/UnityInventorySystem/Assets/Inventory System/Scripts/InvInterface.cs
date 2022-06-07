using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

[RequireComponent(typeof(ExtendedButton))]
public abstract class InvInterface : MonoBehaviour
{
    public PlayerInv pInv;
    public InventorySO inv;
    public GameObject interfaceUI;
    public Transform itemSlotContainer;
    public InvInterface[] otherInterfaces;
    protected ExtendedButton exBTN;
    protected Sprite defaultItemIMG;
    [SerializeField] Vector2 itemIMGSize = new Vector2(100, 100);


    public Dictionary<GameObject, InvSlot> itemsDisplayed = new Dictionary<GameObject, InvSlot>();

    
    Vector2 mousePos;
    public abstract void SetupSlots();
    public enum InterfaceTypes
    {
        Player,
        External
    }
    public InterfaceTypes interfaceType = InterfaceTypes.Player;
    protected void Awake()
    {
        exBTN = GetComponent<ExtendedButton>();
        if (interfaceMode == InterfaceModes.AlwaysOpen) currState = InterfaceStates.Open;
    }
    protected void GetExtendedBTN()
    {
        exBTN = GetComponent<ExtendedButton>();
    }
    void Start()
    {
        if(inv != null) Setup();
        
    }
    private void Update()
    {
        if (inv != null) UpdateSlots();
    }
    protected void Setup()
    {
        defaultItemIMG = inv.db.defaultItem.image;
        for (int i = 0; i < inv.contents.invSlots.Length; i++)
        {
            inv.contents.invSlots[i].interfaceRef = this;
        }
        SetupSlots();
        UpdateSlots();
        exBTN.SetPointerActions((/*OnEnter*/) => {
            OnEnterInterface(gameObject);
        },

        (/*OnExit*/) => {
            OnExitInterface(gameObject);
        });
    }
    protected void Inv_OnInvChanged(object sender, System.EventArgs e)
    {
        UpdateSlots();
    }
    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject,InvSlot> _slot in itemsDisplayed)
        {
            InterfaceSlot iSlot = _slot.Key.GetComponent<InterfaceSlot>();
            InvSlot currSlot = _slot.Value;
            if (currSlot.ID >= 0)
            {
                
                iSlot.Setup(inv.db.GetItemById(currSlot.item.Id).image, currSlot.amount);
            }
            else { iSlot.Setup(null, 0); }
        }
    }
    protected void ClearUI()
    {
        foreach (Transform child in itemSlotContainer)
        {
            Destroy(child.gameObject);
        }
        if (itemsDisplayed != null) { itemsDisplayed.Clear(); }

    }
    public void SetInventory(InventorySO _inv)
    {
        inv = _inv;
    }
    public void OnEnter(GameObject obj)
    {
        pInv.mouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            pInv.mouseItem.hoverItem = itemsDisplayed[obj];
    }
    public void OnExit(GameObject obj)
    {
        pInv.mouseItem.hoverObj = null;
        pInv.mouseItem.hoverItem = null;
    }
    public void OnEnterInterface(GameObject obj)
    {
        pInv.mouseItem.ui = obj.GetComponent<InvInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        pInv.mouseItem.ui = null;
    }
    public void OnDragStart(GameObject obj)
    {
        CreateDragObj(itemIMGSize, itemsDisplayed[obj]);
    }
    public void OnDragEnd(GameObject obj)
    {
        var itemOnMouse = pInv.mouseItem;
        var mouseHoverItem = itemOnMouse.hoverItem;
        var mouseHoverObj = itemOnMouse.hoverObj;
        var itemData = inv.db;
        if(itemOnMouse.ui != null)
        {
            if (mouseHoverObj && obj != mouseHoverObj)
            {
                if (mouseHoverItem.CanPlaceInSlot(itemData.GetItemById(itemsDisplayed[obj].ID)) && (mouseHoverItem.ID <= -1 || (mouseHoverItem.ID >= 0 && itemsDisplayed[obj].CanPlaceInSlot(itemData.GetItemById(mouseHoverItem.ID)))))
                {
                    inv.MoveItem(itemsDisplayed[obj], mouseHoverItem.interfaceRef.itemsDisplayed[itemOnMouse.hoverObj]);
                }
            }
        }
        else
        {
            inv.DropStack(itemsDisplayed[obj]);
        }
        Destroy(itemOnMouse.obj);
        itemOnMouse.item = null;
    }
    public void OnDrag(GameObject obj)
    {
        if (pInv.mouseItem.obj != null)
        {
            var rt = pInv.mouseItem.obj.GetComponent<RectTransform>();
            rt.position = mousePos;
        }
    }
    public void CreateDragObj(Vector2 imgSize, InvSlot _itemSlot)
    {
        Debug.Log("Creating Drag Obj");
        if (_itemSlot.item == null) { Debug.Log("No item to drag/create drag obj with... Cancelling!"); return; }
        var dragObj = new GameObject();
        var rt = dragObj.AddComponent<RectTransform>();
        rt.SetParent(this.transform);
        rt.sizeDelta = imgSize;

        var img = dragObj.AddComponent<Image>();
        img.sprite = _itemSlot.item.Id != -1 ? (inv.db.GetItemById(_itemSlot.item.Id).image != null ? inv.db.GetItemById(_itemSlot.item.Id).image : defaultItemIMG) : defaultItemIMG;
        img.raycastTarget = false;

        pInv.mouseItem.obj = dragObj;
        pInv.mouseItem.item = _itemSlot;
    }
    public void SetCursorPos(Vector2 pos)
    {
        mousePos = pos;
    }

    public enum InterfaceStates
    {
        Open,
        Closed
    }
    public enum InterfaceModes
    {
        Toggle,
        AlwaysOpen
    }
    public InterfaceModes interfaceMode = InterfaceModes.Toggle;
    protected InterfaceStates currState = InterfaceStates.Closed;
    protected InterfaceStates InvState { get { return currState; } private set { currState = value; SwitchState(); } }
    public void OpenInventory(bool forceOpen)
    {
        if (interfaceMode == InterfaceModes.AlwaysOpen && !forceOpen) return;
        if (currState != InterfaceStates.Open) InvState = InterfaceStates.Open;
        
    }
    public void OpenWithInventory(InventorySO _inv, bool forceOpen)
    {
        inv = _inv;
        InvState = InterfaceStates.Open;
        Setup();
        if (otherInterfaces.Length > 0)
        {
            foreach (InvInterface other in otherInterfaces)
            {
                other.OpenInventory(false);
            }
        }
    }
    public void CloseInventory(bool forceClose)
    {
        if (interfaceMode == InterfaceModes.AlwaysOpen && !forceClose) return;
        if (currState != InterfaceStates.Closed) InvState = InterfaceStates.Closed;
    }
    public void ToggleInventory(bool forceToggle)
    {
        if (interfaceMode == InterfaceModes.AlwaysOpen && !forceToggle) return;
        if (interfaceType == InterfaceTypes.External && currState == InterfaceStates.Closed) return;
        if (currState == InterfaceStates.Closed) { InvState = InterfaceStates.Open; return; }
        if (currState == InterfaceStates.Open) InvState = InterfaceStates.Closed;
    }
    protected void SwitchState()
    {
        switch (currState)
        {
            case InterfaceStates.Open:
                interfaceUI.SetActive(true);
                UpdateSlots();
                break;
            case InterfaceStates.Closed:
                interfaceUI.SetActive(false);
                UpdateSlots();
                break;
        }
    }
}
public class MouseItem
{
    public InvInterface ui;
    public GameObject obj;
    public InvSlot item;
    public InvSlot hoverItem;
    public GameObject hoverObj;
}
