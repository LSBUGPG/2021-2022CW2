using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public Animator animator;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        animator.SetTrigger("Hurt");
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            animator.SetTrigger("Death");
        }
    }
}
