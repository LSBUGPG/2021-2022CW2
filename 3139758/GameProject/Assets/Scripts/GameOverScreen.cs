using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    public static bool gameIsOver = false;
    public PlayerHealth health;
    public GameObject gameOver;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEnd;

    private void Update()
    {
        scoreText.text = "Coins: " + ScoreManager.score;
        scoreTextEnd.text = "Coins: " + ScoreManager.score;

        if (health.currentHealth == 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0f;
            gameIsOver = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }
}
