using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FoodInventory : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI IngredientTxt;
    int DairyCount;
    int VegCount;
    int MeatCount;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        IngredientTxt.text = ("<b>Ingredients</b> \n" +
                              "Dairy: " + DairyCount + "\n" +
                              "Veg: " + VegCount + "\n" +
                              "Meat: " + MeatCount);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dairy")
        {
            DairyCount++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Veg")
        {
            VegCount++;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Meat")
        {
            MeatCount++;
            Destroy(other.gameObject);
        }
    }
}
