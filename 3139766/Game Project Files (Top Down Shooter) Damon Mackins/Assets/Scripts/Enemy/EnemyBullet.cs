using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().HurtPlayer(1);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject, 0.02f);
        }
    }

    void Update()
    {
        Destroy(gameObject, 3f);
    }
}
