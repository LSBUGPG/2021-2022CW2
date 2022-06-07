using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Item Database")]
public class ItemDatabaseSO : ScriptableObject, ISerializationCallbackReceiver
{
    public ItemSO defaultItem;
    public ItemSO[] items;
    public Dictionary<int, ItemSO> itemIDs = new Dictionary<int, ItemSO>();

    
    public void OnAfterDeserialize()
    {
        itemIDs = new Dictionary<int, ItemSO>();
        for (int i = 0; i < items.Length; i++)
        {
            items[i].Id = i;
            itemIDs.Add(i, items[i]);
        }

    }
    public int GetIDbyItem(ItemSO _item)
    {
        if (_item == null) { return -1; }
        foreach (KeyValuePair<int, ItemSO> kvp in itemIDs)
        {
            if (kvp.Value == _item) { return kvp.Key; }
        }
        return -1;
    }
    public ItemSO GetItemById(int _id)
    {
        if(_id == -1) { return null; }
        foreach (KeyValuePair<int,ItemSO> kvp in itemIDs)
        {
            if(kvp.Key == _id) { return kvp.Value; }
        }
        return null;
    }

    public void OnBeforeSerialize()
    {
        itemIDs = new Dictionary<int, ItemSO>();
    }
}
