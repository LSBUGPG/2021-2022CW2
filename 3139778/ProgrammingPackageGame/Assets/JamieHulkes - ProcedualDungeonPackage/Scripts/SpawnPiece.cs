using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPiece : MonoBehaviour
{
    [SerializeField] private GameObject room;

    void Start()
    {
        Instantiate(room, transform.position, Quaternion.identity);
    }
}
