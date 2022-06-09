using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 4;
    public static int currentHealth;
    public HealthBar healthBar;
    public GameObject player;

    public float invincibilityLength = 2f;
    public float invincibilityCounter;

    public Renderer playerRend;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    public Vector2 respawnPoint;
    public float respawnDelay = 2f;

    private bool isGameOVer = false;
    public GameObject gameOverMenuUI;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        respawnPoint = player.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "EnemyProjectile")
        {
            HurtPlayer(1);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            HurtPlayer(1);
        }
    }

    void Update()
    {
         if (invincibilityCounter > 0)
          {
                invincibilityCounter -= Time.deltaTime;

                flashCounter -= Time.deltaTime;

                if (flashCounter <= 0)
                {
                    playerRend.enabled = !playerRend.enabled;
                    flashCounter = flashLength;
                }

                if (invincibilityCounter <= 0)
                {
                    playerRend.enabled = true;
                }
          }

        if (isGameOVer == true)
        {
            GameOver();
        }
    }

    public void HurtPlayer(int damage)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                isGameOVer = true;
            }
            else
            {
                invincibilityCounter = invincibilityLength;

                playerRend.enabled = false;

                flashCounter = flashLength;

                isGameOVer = false;
            }
        }
    }

    public void GameOver()
    {
        gameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
