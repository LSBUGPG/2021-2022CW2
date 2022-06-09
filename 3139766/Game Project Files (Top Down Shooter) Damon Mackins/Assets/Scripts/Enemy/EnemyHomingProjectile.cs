using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHomingProjectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        Destroy(gameObject, 2);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStats>().HurtPlayer(1);
            Destroy(gameObject);
        }
    }
}
