using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
 //   private bool isGameOver;


    public GameObject gameOverMenuUI;

    void Start()
    {
        Resume();
    }

    public void Resume()
    {
      ///  isGameOver = false;
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Resume();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        ScoreManager.scoreValue = 0;
        Resume();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("QUITTING GAME");
        Application.Quit();
    }
}
