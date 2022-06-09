using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject YouWinScreen;

    private void OnTriggerEnter(Collider other)
    {
        YouWinScreen.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Quit");
        //Application.Quit();
    }
}
