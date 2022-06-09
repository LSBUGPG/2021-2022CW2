using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coinsLeft;

    public TextMeshProUGUI coinsText;

    [SerializeField] GameObject dialog;

    private void Update()
    {
        coinsText.text = "Coins Left: " + coinsLeft;

        if (coinsLeft == 0)
        {
            coinsLeft = -1000;
            dialog.SetActive(true);
        }
    }
}
