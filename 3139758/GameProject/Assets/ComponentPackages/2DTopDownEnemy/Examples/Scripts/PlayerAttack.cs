using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (timeBtwAttack <= 0)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
