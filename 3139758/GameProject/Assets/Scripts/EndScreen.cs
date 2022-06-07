using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject canvas;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        endScreen = canvas.transform.Find("EndScreen").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("PlayerEntered");
            endScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
