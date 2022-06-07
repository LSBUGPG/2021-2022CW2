using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Standard,
    Weapon,
    Gadget,
    Consumable
}
public abstract class ItemSO : ScriptableObject
{
    public int Id;
    public string itemName;
    [TextArea(10, 15)]
    public string description;
    public ItemTypes type;
    public Sprite image;
    public GameObject prefab;
    public bool limitStack = true;
    public int maxStack = 100;
}
[System.Serializable]
public class Item
{
    public string name;
    public int Id = -1;
    public Item()
    {
        name = null;
        Id = -1;
    }
    public Item(ItemSO item)
    {
        name = item.itemName;
        Id = item.Id;
    }
}
