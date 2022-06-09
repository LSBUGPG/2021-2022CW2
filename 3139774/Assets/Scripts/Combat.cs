using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Combat : MonoBehaviour
{

    public Transform AttackPoint;

    public float AttackRange = 0.5f;

    public LayerMask EnemyLayers;

    public int attackDamage = 10;

    public Animator animator;
    // Start is called before the first frame update
    void Attack()
    {
      Collider[] hitEnemies= Physics.OverlapSphere(AttackPoint.position,AttackRange,EnemyLayers);

     animator.SetTrigger("Attack");
      foreach (Collider Enemy in hitEnemies)
      {
          Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

      }
      
      
    }

    private class Enemy
    {
        public void TakeDamage(int i)
        {
            throw new NotImplementedException();
        }
    }

    private void OnDrawGizmos()
    {
        if (AttackPoint == null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position,AttackRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Attack();
        }
    }
}
