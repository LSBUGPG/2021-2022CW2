using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] objectsArray;
    public Transform player;

    public float spawnDelay = 3f;
    public float spawnTime = 3f;
    private bool stopSpawning = false;

    public Camera cam;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update()
    {
        
    }

    public void SpawnObject()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(0, 100), Random.Range(0, 100));
        Instantiate(objectsArray[Random.Range(0, objectsArray.Length)], spawnPosition, Quaternion.identity);
        if (stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
}
