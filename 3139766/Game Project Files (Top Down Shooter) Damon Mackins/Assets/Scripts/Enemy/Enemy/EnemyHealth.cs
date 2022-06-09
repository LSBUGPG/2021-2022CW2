using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damageToGive = 1;

    private EnemyHealthBar healthBar;


    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerProjectile")
        {
            HurtEnemy(damageToGive);
        }
    }

    public void HurtEnemy(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            ScoreManager.scoreValue += 10;
            gameObject.SetActive(false);
            Destroy(gameObject, 2f);
        }
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
