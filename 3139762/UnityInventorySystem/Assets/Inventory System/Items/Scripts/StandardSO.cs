using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Standard Item", menuName = "Inventory System/Items/Standard")]
public class StandardSO : ItemSO
{
    private void Awake()
    {
        type = ItemTypes.Standard;
    }
}
