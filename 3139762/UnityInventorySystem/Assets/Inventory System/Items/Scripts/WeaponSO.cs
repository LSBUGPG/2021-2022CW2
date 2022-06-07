using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory System/Items/Weapon")]
public class WeaponSO : ItemSO
{
    private void Awake()
    {
        type = ItemTypes.Weapon;
    }
    public float damageAmount;
    public float rateOfAttack = 1;
}
