using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public ItemDrop itemDrop;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            itemDrop.DropItem();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("damage Taken");
    }
}
