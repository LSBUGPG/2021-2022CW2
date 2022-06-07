using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] float Spikespeed;

    int NextPositionIndex;

    Transform Nextposition;

    // Start is called before the first frame update
    void Start()
    {
        Nextposition = positions[0];   
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }
    void MoveGameObject()
    {
        if (transform.position == Nextposition.position)
        {
            NextPositionIndex++;
            if (NextPositionIndex >= positions.Length)
            {
                NextPositionIndex = 0;
            }
            Nextposition = positions[NextPositionIndex];
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Nextposition.position, Spikespeed * Time.deltaTime);
        }
    }
}
