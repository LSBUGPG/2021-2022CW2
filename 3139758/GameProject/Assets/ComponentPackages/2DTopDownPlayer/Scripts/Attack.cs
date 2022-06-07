using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPosUp;
    public Transform attackPosDown;
    public Transform attackPosLeft;
    public Transform attackPosRight;
    
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    public Animator animator;

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (gameObject.GetComponent<PlayerMovement>().inputEnable == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastVertical") > 0.01)
                    {
                        animator.SetTrigger("Attack");
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosUp.position, attackRange, whatIsEnemies);
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                        }
                        timeBtwAttack = startTimeBtwAttack;
                    }

                    if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastVertical") < -0.01)
                    {
                        animator.SetTrigger("Attack");
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosDown.position, attackRange, whatIsEnemies);
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                        }
                        timeBtwAttack = startTimeBtwAttack;
                    }

                    if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastHorizontal") < -0.01)
                    {
                        animator.SetTrigger("Attack");
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosLeft.position, attackRange, whatIsEnemies);
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                        }
                        timeBtwAttack = startTimeBtwAttack;
                    }

                    if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastHorizontal") > 0.01)
                    {
                        animator.SetTrigger("Attack");
                        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPosRight.position, attackRange, whatIsEnemies);
                        for (int i = 0; i < enemiesToDamage.Length; i++)
                        {
                            enemiesToDamage[i].GetComponent<EnemyHealth>().TakeDamage(damage);
                        }
                        timeBtwAttack = startTimeBtwAttack;
                    }
                }
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPosUp.position, attackRange);
        Gizmos.DrawWireSphere(attackPosDown.position, attackRange);
        Gizmos.DrawWireSphere(attackPosLeft.position, attackRange);
        Gizmos.DrawWireSphere(attackPosRight.position, attackRange);
    }
}
