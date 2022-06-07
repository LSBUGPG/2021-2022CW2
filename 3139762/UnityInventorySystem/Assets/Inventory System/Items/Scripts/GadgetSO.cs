using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gadget Item", menuName = "Inventory System/Items/Gadget")]
public class GadgetSO : ItemSO
{
    private void Awake()
    {
        type = ItemTypes.Gadget;
    }
}
