using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteract : MonoBehaviour
{
    public GameObject InteractText;
    public GameObject ShopUI;
    public bool ObjectIsHighlighted = false;
    public GameObject Reticle;


    //i need a 'note is open' to know when to disable the note.

    private void OnMouseOver()
    {
        InteractText.SetActive(true);
        Reticle.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractText.SetActive(false);
            ShopUI.SetActive(true);
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnMouseExit()
    {
        InteractText.SetActive(false);
        ObjectIsHighlighted = false;
        Reticle.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && ShopUI == true)
        {
            ShopUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
