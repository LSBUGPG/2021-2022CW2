using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;
    [SerializeField]
    GameObject player;
    [SerializeField]
    Transform enemyParent;
    [SerializeField]
    float maxEnemies;

    void Update()
    {
        if(enemyParent.childCount < maxEnemies)
        {
            GameObject i_enemy = Instantiate(enemy, enemyParent);
            i_enemy.transform.position += new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            i_enemy.transform.LookAt(player.transform);
        }
    }
}
