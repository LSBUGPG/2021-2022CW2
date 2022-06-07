using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int randEnemy;

    private void Start()
    {
        randEnemy = Random.Range(0, 10);

        if (randEnemy == 3 || randEnemy == 6 || randEnemy == 9)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
