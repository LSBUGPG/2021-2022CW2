using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable Item", menuName = "Inventory System/Items/Consumable")]
public class ConsumableSO : ItemSO
{
    private void Awake()
    {
        type = ItemTypes.Consumable;
    }
    public float healthIncrease;
}
