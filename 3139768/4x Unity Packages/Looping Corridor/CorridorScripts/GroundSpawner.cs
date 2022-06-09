using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    // Attach this to an empty gameobject called 'GroundSpawner' & attach your 'hallway' prefab to it.

    public GameObject Hallway;
    Vector3 NextSpawnPoint;
    Quaternion NextSpawnRotation;

    public void SpawnTile()
    {
        GameObject temp = Instantiate(Hallway, NextSpawnPoint, NextSpawnRotation);

        //NextSpawnPoint is the location
        NextSpawnPoint = temp.transform.GetChild(5).transform.position;
        NextSpawnRotation = temp.transform.GetChild(5).transform.rotation * Quaternion.AngleAxis(90.0f, Vector3.up);
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnTile();
        }

    }
}