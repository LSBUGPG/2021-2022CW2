using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    // Attach this script to your 'hallway' prefab
    
    GroundSpawner groundSpawner;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject);
        //Destroy(gameObject, 2);  - the '2' is seconds after the player has left
    }
}
