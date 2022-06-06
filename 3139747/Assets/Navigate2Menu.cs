using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Navigate2Menu : MonoBehaviour
{
    public int MoneyAvailable;
    public GameObject NavigationText;

    // Start is called before the first frame update
    void Start()
    {
        MoneyAvailable = 0; 
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MoneyAvailable += 5;
        }
        if (Input.GetButtonDown("Fire2"))
        {
            MoneyAvailable -= 5;
        }
    }
    // This is an original script that links the "Jukebox" Component to the "ColorSwitching" Component by allowing one to navigate between either scene.
    void OnTriggerEnter(Collider other)
    {
        NavigationText.GetComponent<PlayerMoney>();
        if (MoneyAvailable >=60)
        {
            SceneManager.LoadScene("2D Jukebox Menu");
        }

        if (MoneyAvailable < 60)
        {
            Debug.Log("You need 60 pounds to unlock this feature!");
        }
    }
}
