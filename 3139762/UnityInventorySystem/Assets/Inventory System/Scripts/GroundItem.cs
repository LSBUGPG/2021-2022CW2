using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundItem : MonoBehaviour
{
    Item item;
    [SerializeField] ItemSO itemData;
    [SerializeField] int amount = 1;

    public bool setupDone { get; private set; } = false;
    private void Start()
    {
        if (itemData) { Setup(new Item(itemData), amount); }
        gameObject.AddComponent<Rigidbody>();
    }
    public void Setup(Item _item, int _amount) {
        item = _item;
        amount = _amount;
        if (item != null) setupDone = true;
    }
    public void Setup(ItemSO _item, int _amount)
    {
        item = new Item(itemData);
        amount = _amount;
        if (item != null) setupDone = true;
    }
    public void SetAmount(int _amount)
    {
        amount = _amount;
    }
    public InvSlot GetContents()
    {
        InvSlot contents = new InvSlot(item.Id, item, amount);
        return contents;
    }
}
