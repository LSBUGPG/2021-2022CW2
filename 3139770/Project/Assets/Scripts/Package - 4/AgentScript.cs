using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{
    public Transform[] targets;
    NavMeshAgent agent;
    Transform theTarget;
    public GameObject playerTarget;

    public int damage = 5;
    public float attackRange = 2f;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestination();
        //agent.SetDestination(theTarget.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (theTarget != null)
        {
            agent.SetDestination(theTarget.position);
        }

        if (playerTarget != null)
        {
            agent.transform.LookAt(playerTarget.transform);

            float playerDistance = Vector3.Distance(transform.position, playerTarget.transform.position);

            if (playerDistance <= attackRange)
            {
                Attack();
            }
        }
    }

    public void SetNewDestination()
    {
        theTarget = targets[Random.Range(0, targets.Length)];
    }

    private void Attack()
    {
        //Debug.Log("ATTACK");
    }
}
