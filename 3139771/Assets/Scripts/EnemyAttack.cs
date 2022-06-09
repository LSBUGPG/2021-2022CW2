using UnityEngine;


public class EnemyAttack : MonoBehaviour
{
    public float Range = 1f;
    public Transform AttackPoint;
    public LayerMask PlayerLayer;

    bool PlayerCheck;
    public float damage = 10f;

    public float AttackSpeed = 4;
    float nextTimeToFire = 0f;



    void Update()
    {
       PlayerCheck =  Physics.CheckSphere(AttackPoint.position, Range, PlayerLayer);

        if (PlayerCheck == true && Time.time >= nextTimeToFire)
        {
            Attack();
            nextTimeToFire = Time.time + 1f / AttackSpeed;
        }
    }

    void Attack()
    {
        FindObjectOfType<PlayerMovement>().currentHealth -= damage;

        if (FindObjectOfType<PlayerMovement>().currentHealth <= 0)
        {
            FindObjectOfType<PlayerMovement>().GameOver();
        }

        UnityEngine.Debug.Log("Damage");
    }



}
