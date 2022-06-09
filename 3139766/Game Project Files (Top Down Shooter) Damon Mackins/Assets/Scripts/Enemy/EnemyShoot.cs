using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float moveSpeed;
    public float stoppingDistance;
    public float retreatDistance;

    public Transform player;
    public GameObject projectile;
    public Transform attackPoint;

    private float timeBtwShots;
    public float startBtwShots;
    public float projectileForce;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShots = startBtwShots;
    }

    void Update()
    {
        transform.right = player.position - transform.position;

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            GameObject bullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(attackPoint.up * projectileForce, ForceMode2D.Impulse);
            timeBtwShots = startBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
