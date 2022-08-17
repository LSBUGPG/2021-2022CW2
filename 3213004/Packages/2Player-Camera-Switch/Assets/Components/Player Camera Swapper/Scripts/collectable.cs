using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            scoreManager.instance.AddPlayer1Score();
            Destroy(gameObject);
        }
        if (other.tag == "Player2")
        {
            scoreManager.instance.AddPlayer2Score();
            Destroy(gameObject);
        }
    }
}
