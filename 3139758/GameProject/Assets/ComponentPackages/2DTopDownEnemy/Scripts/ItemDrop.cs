using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    public GameObject[] itemList;
    private int itemIndex;
    private int totalItemsInArray = 0;
    private Transform enemyPos;

    private void Start()
    {
        foreach (GameObject  item in itemList)
        {
            totalItemsInArray++;
        }
        itemIndex = Random.Range(0, totalItemsInArray);
    }

    public void DropItem()
    {
        enemyPos = GetComponent<Transform>();
        Instantiate(itemList[itemIndex], enemyPos.position, Quaternion.identity);
    }
}
