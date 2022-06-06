using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform SpawnLocation;
    public GameObject Prefab;

    private void OnTriggerEnter(Collider other)
    {

        Instantiate(Prefab, SpawnLocation.position, SpawnLocation.rotation);
    }
}
