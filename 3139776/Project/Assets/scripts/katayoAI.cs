using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class katayoAI : MonoBehaviour
{
    public Transform[] waypointsfront;
    public Transform[] waypointsback;
    NavMeshAgent agent;
    Transform TheWaypoint;
    int currentwaypointID;
    int previouswaypoint = 0;
    //
    public float timeBetweenWaypoints = 2f;


    public Transform player;
    public LayerMask whatIsPlayer;


    

    


    //Attacking
    public float timeBetweenAttacks = 4f;
    
    bool alreadyAttacked;



    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        
        player = GameObject.Find("FirstPersonController").transform;
        
    }


   


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewDestinationfront();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TheWaypoint != null)
        {
            agent.SetDestination(TheWaypoint.position);
            
        }

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

       
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();

    }

    public void SetNewDestinationfront()
    {
        do
        {
            currentwaypointID = Random.Range(0, waypointsfront.Length);
            print("walking");
            

        }
        while (waypointsfront[currentwaypointID].GetComponent<waypoints>().ID == previouswaypoint);
        
        TheWaypoint = waypointsfront[currentwaypointID];
        previouswaypoint = waypointsfront[currentwaypointID].GetComponent<waypoints>().ID;

        
}


    public void SetNewDestinationback()
    {
        do
        {
            currentwaypointID = Random.Range(0, waypointsback.Length);
            print("walking");


        }
        while (waypointsback[currentwaypointID].GetComponent<waypoints>().ID == previouswaypoint);

        TheWaypoint = waypointsback[currentwaypointID];
        previouswaypoint = waypointsback[currentwaypointID].GetComponent<waypoints>().ID;


    }


    

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesnt move
        agent.SetDestination(transform.position);
        transform.LookAt(player);
        print("attack");



        //Attackcode here
        //if ( player.GetComponent<FirstPersonController>().isSliding)
       // {
       //     alreadyAttacked = true;
      //  }
       // else
        //    player.GetComponent<FirstPersonController>().KillPlayer();
        //
//
        //if (!alreadyAttacked)
        //{
          //  
        //
          //  alreadyAttacked = true;
          //  Invoke(nameof(ResetAttack), timeBetweenAttacks);

       // }

        //Attackcode here
        


        if (alreadyAttacked)
        {
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
            // alreadyAttacked = false;
            print("cooldown");

        }

        if (player.GetComponent<FirstPersonController>().isSliding)
        {
            alreadyAttacked = true;
            
        }
        else
            print("dead");
        player.GetComponent<FirstPersonController>().KillPlayer();
        
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
