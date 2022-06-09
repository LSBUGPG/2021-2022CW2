using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public delegate void EnemyKilled();

    public TextMesh HealthIndicator;

     

    public static event EnemyKilled OnEnemyKilled;
    public int maxHealth = 100;

    private int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = maxHealth;
        HealthIndicator.text = CurrentHealth.ToString();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (HealthIndicator!=null)
        {
            HealthIndicator.text = CurrentHealth.ToString();
        }

        if (CurrentHealth<=0)
        {
            Die();
        }
        
    }

    void Die()
    {
        Debug.Log("Enemy Dies");
        Destroy(gameObject);
    }

    public void Died()
    {
        if (OnEnemyKilled!=null)
        {
            OnEnemyKilled();
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Punchball")
        {
            TakeDamage(5);
            transform.Translate(1f,0,0);
        }
        
        if (other.tag=="KickBall")
        {
            TakeDamage(10);
            transform.Translate(1f,0,0);
        }
        if (other.tag=="SweepBall")
        {
            TakeDamage(5);
            transform.Translate(0.5f,1f,0);
        }

        if (other.tag=="Fire")
        {
            TakeDamage(1);
        }
    }
}
