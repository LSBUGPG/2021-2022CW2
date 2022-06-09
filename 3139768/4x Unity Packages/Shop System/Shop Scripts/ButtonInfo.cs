using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonInfo : MonoBehaviour
{
    // Attach this to the Items in the shop UI.
    // For me (in the Demo scene) they are under 'Canvas, Scroll View, Viewport, Content'
    // Then the script is on my 'Item1, Item2, Item3, Item4'. 

    public int ItemID;
    public Text PriceText;
    public Text QuantityText;
    public GameObject ShopManager;

    void Update()
    {
        PriceText.text = "Price: $" + ShopManager.GetComponent<ShopManagerScript>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<ShopManagerScript>().shopItems[3, ItemID].ToString();
    }
}
