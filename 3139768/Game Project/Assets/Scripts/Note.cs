using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public GameObject InteractText;
    public GameObject Note1;
    public bool ObjectIsHighlighted = false;
    public GameObject Reticle;

    private void OnMouseOver()
    {
        InteractText.SetActive(true);
        Reticle.SetActive(false);

        if (Input.GetKeyDown(KeyCode.E))
        {
            InteractText.SetActive(false);
            Note1.SetActive(true);
            Time.timeScale = 0;
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
        if (Input.GetKeyDown(KeyCode.Tab) && Note1 == true)
        {
            Note1.SetActive(false);
            Time.timeScale = 1;
        }
    }
}