using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();
    public event EventHandler<Item> OnItemSelected;

    [SerializeField] private List<Item> itemList;

    public Transform itemTemplate;
    private Dictionary<Item, Transform> itemTransformDic;

    public Transform itemContent;
    public GameObject inventoryItem;

    public static bool InventoryIsOpen = false;
    public bool invOpen = false;
    public GameObject inventoryUI;
    public GameObject inventoryBG;
    //public FirstPersonController FPC;
    public GameObject item3DViewer;

    private void Awake()
    {
        instance = this;
        
        itemTemplate = transform.Find("Item");
        //itemTemplate.gameObject.SetActive(false);

        itemTransformDic = new Dictionary<Item, Transform>();

        foreach (Item item in itemList)
        {
            Transform itemTransform = Instantiate(itemTemplate, transform);
            itemTransform.gameObject.SetActive(true);
            itemTransform.Find("ItemIcon").GetComponent<Image>().sprite = item.icon;

            itemTransformDic[item] = itemTransform;
       
            itemTransform.GetComponent<Button>().onClick.AddListener(() => 
            {
                SelectItem(item);
            });
        } 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ListItems();

            if (InventoryIsOpen)
            {
                CloseInventory();
            }
            else
            {
                OpenInventory();
            }
        }
        invOpen = InventoryIsOpen;
    }

    public void CloseInventory()
    {
        //Time.timeScale = 1f;
        //Movement.enabled = true;
        item3DViewer.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inventoryUI.SetActive(false);
        //inventoryBG.SetActive(false);
        InventoryIsOpen = false;
    }

    public void OpenInventory()
    {
        //Time.timeScale = 0f;
        //Movement.enabled = false;
        item3DViewer.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        inventoryUI.SetActive(true);
        //inventoryBG.SetActive(true);
        InventoryIsOpen = true;
    }

    public void Add(Item item)
    {
        items.Add(item);
    }

    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            //var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            //var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            ItemSlotUI itemObjCtrl = obj.GetComponent<ItemSlotUI>();

            itemObjCtrl.Setup(item);

            //itemName.text = item.Name;
            //itemIcon.sprite = item.icon;
        }
    }

    private void SelectItem(Item selectedItem)
    {
        foreach (Item item in itemTransformDic.Keys)
        {
            itemTransformDic[item].Find("Item").gameObject.SetActive(false);
        }

        itemTransformDic[selectedItem].Find("Item").gameObject.SetActive(true);

        OnItemSelected?.Invoke(this, selectedItem);
    }
}