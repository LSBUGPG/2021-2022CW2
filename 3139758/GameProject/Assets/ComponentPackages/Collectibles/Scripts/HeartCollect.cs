using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public int health;
    public int maxHealth;

    private void Update()
    {
        health = GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth;
        maxHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (health < maxHealth && collision.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().currentHealth += 1;
            Destroy(gameObject);
        }
    }
}
