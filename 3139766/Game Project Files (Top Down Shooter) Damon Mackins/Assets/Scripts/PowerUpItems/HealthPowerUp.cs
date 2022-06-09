using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerUp : MonoBehaviour
{
    public int healthValue = 1;
    public HealthBar healthBar;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerStats.currentHealth < 4)
            {
                PlayerStats.currentHealth += healthValue;
                healthBar.SetHealth(PlayerStats.currentHealth);
                Destroy(gameObject);
            }
        }
    }
}
