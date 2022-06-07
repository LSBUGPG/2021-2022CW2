using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public int damage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Hit");
        Destroy(gameObject, 0.1f);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
