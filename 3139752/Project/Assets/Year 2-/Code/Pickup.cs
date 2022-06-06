using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private UIController ui;
    // Start is called before the first frame update
    void Start()
    {
        ui = GameObject.FindObjectOfType<UIController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ui.IncreaseScore(10);
            Destroy(gameObject);
        }
    }
}