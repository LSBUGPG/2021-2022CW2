using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public static scoreManager instance;
    public static int player1score, player2score;
    public TMP_Text player1scoreText, player2scoreText;

    private void Awake()
    {
        instance = this;
    }

    public void AddPlayer1Score()
    {
        player1score++;
        player1scoreText.text = player1score.ToString();
    }

    public void AddPlayer2Score()
    {
        player2score++;
        player2scoreText.text = player2score.ToString();
    }
}