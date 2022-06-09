using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targets : MonoBehaviour
{
    private AgentScript Enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy = other.GetComponent<AgentScript>();
            Enemy.SetNewDestination();
        }
    }
}
