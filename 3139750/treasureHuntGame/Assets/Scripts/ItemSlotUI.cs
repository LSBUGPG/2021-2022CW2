using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    Item item;
    Item3DViewer viewer;

    [SerializeField] Image itemIMG;

    private void Awake()
    {
        viewer = FindObjectOfType<Item3DViewer>();
    }
    public void Setup(Item _item)
    {
        item = _item;

        itemIMG.sprite = item.icon;
    }

    public void ViewItem()
    {
        viewer.SetViewItem(item);
    }
}
