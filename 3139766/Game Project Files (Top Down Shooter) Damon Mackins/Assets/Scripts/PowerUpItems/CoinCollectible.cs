using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour
{
    public float coinValue = 10f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            ScoreManager.scoreValue += coinValue;
            Destroy(gameObject);
        }
    }
}
