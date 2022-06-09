using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSpawner : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject pieceSpawner;

    void Awake()
    {
        wall.SetActive(false);
        pieceSpawner.SetActive(false);

        bool wallActive = (Random.value > 0.65f);
        //private bool wallActive;

        if (wallActive)
        {
            //Instantiate(wall, new Vector3(0, 0, 0), Quaternion.identity);
            wall.SetActive(true);
            Destroy(pieceSpawner);
        }

        else
        {
            pieceSpawner.SetActive(true);
            Destroy(wall);

            //pieceSpawner.transform.parent = this.transform;
        }
    }
}
