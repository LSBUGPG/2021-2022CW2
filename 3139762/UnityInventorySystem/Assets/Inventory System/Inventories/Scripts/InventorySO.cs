using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;
using System.Runtime.Serialization;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventorySO : ScriptableObject
{
    public ItemDatabaseSO db;
    public Transform dropP;
    public Inventory contents;

    public string savePath;

    public event EventHandler OnInvChanged;

    private void OnEnable()
    {
        db = Resources.Load<ItemDatabaseSO>("ItemDatabase");
    }

    public bool IsInvFull()
    {
        bool full = true;
        for (int i = 0; i < contents.invSlots.Length; i++)
        {
            if (contents.invSlots[i].ID == -1) { full = false; break; }
        }
        return full;
    }

    public void AddItem(InvSlot contents)
    {
        AddItem(contents.item, contents.amount);
    }
    public void AddItem(Item _item, int _amount)
    {
        if (_amount <= 0) return;
        if (_item == null) return;
        if (_item.Id <= -1) return;
        if (IsInvFull())
        {
            Debug.Log("Inventory: '" + name + "' is full! Dropping item(s)...");
            DropStack(new InvSlot(_item.Id, _item, _amount));
            return;
        }

        var _itemData = db.GetItemById(_item.Id);

        bool stackable = _itemData.maxStack > 1 ? true : false;
        int remaining = 0;
        if (stackable)
        {
            for (int i = 0; i < contents.invSlots.Length; i++)
            {
                var currInvSlot = contents.invSlots[i];
                if (currInvSlot.item.Id == _item.Id)
                {
                    if (db.GetItemById(_item.Id).limitStack)
                    {
                        if (currInvSlot.amount >= _itemData.maxStack) { continue; }
                        else if (_amount + currInvSlot.amount > _itemData.maxStack)
                        {
                            remaining = (_amount + currInvSlot.amount) - _itemData.maxStack;
                            currInvSlot.amount = _itemData.maxStack;
                            break;
                        }
                        else
                        {
                            currInvSlot.AddAmount(_amount);
                            break;
                        }
                    }
                    else
                    {
                        currInvSlot.AddAmount(_amount);
                        break;
                    }
                }
                if (i == contents.invSlots.Length - 1) { stackable = false; break; }
            }
        }
        if (!stackable)
        {
            foreach (InvSlot slot in contents.invSlots)
            {
                if(slot.ID == -1)
                {
                    if (_amount > _itemData.maxStack)
                    {
                        remaining = _amount - _itemData.maxStack;
                        slot.ID = _item.Id;
                        slot.item = _item;
                        slot.amount = _itemData.maxStack;
                        break;
                    }
                    else
                    {
                        slot.ID = _item.Id;
                        slot.item = _item;
                        slot.amount = _amount;
                        break;
                    }
                }
            }
        }
        if(remaining > 0)
        {
            AddItem(_item, remaining);
        }
        OnInvChanged?.Invoke(this, EventArgs.Empty);
    }
    public void MoveItem(InvSlot sending, InvSlot receiving)
    {
        InvSlot temp = new InvSlot(receiving.item != null ? receiving.item.Id : -1, receiving.item, receiving.amount);

        if(receiving.ID >= 0)
        {
            bool stackable = receiving.ID == sending.ID ? true : false;

            if (stackable)
            {
                bool limitStack = db.GetItemById(temp.item.Id).limitStack;

                if (limitStack)
                {
                    int maxStack = db.GetItemById(temp.item.Id).maxStack;

                    if (temp.amount >= maxStack) stackable = false;
                    else if(temp.amount + sending.amount > maxStack)
                    {
                        int amountToAdd = maxStack - temp.amount;

                        receiving.AddAmount(amountToAdd);
                        sending.AddAmount(-amountToAdd);
                        return;
                    }else if(temp.amount + sending.amount <= maxStack) { limitStack = false; }
                }
                if(!limitStack)
                {
                    receiving.AddAmount(sending.amount);
                    sending.ClearSlot();
                }
            }
            if(!stackable)
            {
                receiving.UpdateSlot(sending.item.Id, sending.item, sending.amount);
                sending.UpdateSlot(temp.item.Id, temp.item, temp.amount);
            }
            
        }
        else
        {
            receiving.UpdateSlot(sending.item.Id, sending.item, sending.amount);
            sending.UpdateSlot(temp.ID, temp.item, temp.amount);
        }
        



        OnInvChanged?.Invoke(this, EventArgs.Empty);
        Debug.Log("Item moved");
    }
    public void DropStack(InvSlot invSlot)
    {
        ItemSO itemData = db.GetItemById(invSlot.item.Id);
        GameObject itemPrefab = itemData.prefab != null ? itemData.prefab : db.defaultItem.prefab;
        GameObject droppedPrefab = Instantiate(itemPrefab, dropP.position, Quaternion.identity);
        GroundItem prefabGI = droppedPrefab.GetComponent<GroundItem>();
        prefabGI.enabled = true;
        prefabGI.Setup(invSlot.item, invSlot.amount);
        Debug.Log("Dropped Item: " + invSlot.item.name + " x" + invSlot.amount);
        invSlot.ClearSlot();

        
        OnInvChanged?.Invoke(this, EventArgs.Empty);
    }
    [ContextMenu("Save Inventory")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, contents);
        stream.Close();
        Debug.Log("Inventory Saved");
    }
    [ContextMenu("Load Inventory")]
    public void Load()
    {
        if(File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            contents = (Inventory)formatter.Deserialize(stream);
            stream.Close();
            Debug.Log("Inventory Loaded");
        }
        OnInvChanged?.Invoke(this, EventArgs.Empty);
    }
    [ContextMenu("Clear Inventory")]
    public void Clear()
    {
        contents = new Inventory();
        Debug.Log("Inventory Cleared");
    }
}
[System.Serializable]
public class Inventory
{
    public InvSlot[] invSlots = new InvSlot[24];
    public void Clear()
    {
        for (int i = 0; i < invSlots.Length; i++)
        {
            invSlots[i].UpdateSlot(-1, new Item(), 0);
        }
    }
}

[System.Serializable]
public class InvSlot
{
    public ItemTypes[] allowedItems = new ItemTypes[0];
    public int ID = -1;
    public InvInterface interfaceRef;
    public Item item;
    public int amount;
    public InvSlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public InvSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
    public void UpdateSlot(int _id, Item _item, int _amount)
    {
        ID = _id;
        item = _item;
        amount = _amount;
    }
    public void ClearSlot()
    {
        ID = -1;
        item = null;
        amount = 0;
    }
    public bool CanPlaceInSlot(ItemSO _item)
    {
        if(allowedItems.Length <= 0) { return true; }
        for (int i = 0; i < allowedItems.Length; i++)
        {
            if(_item.type == allowedItems[i]) { return true; }
        }
        return false;
    }
}
