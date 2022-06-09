using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject player;

    public float invincibilityLength = 2f;
    public float invincibilityCounter;

    public Renderer playerRend;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnDelay = 2f;

    void Start()
    {
        currentHealth = maxHealth;

        respawnPoint = player.transform.position;
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
    }

    public void HurtPlayer(int damage)
    {
        if (invincibilityCounter <= 0)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                Respawn();
            }
            else
            {
                invincibilityCounter = invincibilityLength;

                playerRend.enabled = false;

                flashCounter = flashLength;
            }
        }
    }



    public void HealPlayer(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Respawn()
    {
        if (!isRespawning)
        {
            StartCoroutine("RespawnDelay");
        }
    }

    public IEnumerator RespawnDelay()
    {
        isRespawning = true;
        player.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        isRespawning = false;
        player.SetActive(true);


        player.transform.position = respawnPoint;
        currentHealth = maxHealth;

        invincibilityCounter = invincibilityLength;
        playerRend.enabled = false;
        flashCounter = flashLength;
    }

    public void SetSpawnPoint(Vector3 newPosition)
    {
        respawnPoint = newPosition;
    }
}
