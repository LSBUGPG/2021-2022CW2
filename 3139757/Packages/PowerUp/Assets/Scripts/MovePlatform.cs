using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Transform targetObjectiveA;
    public Transform targetObjectiveB;
    public float speed;
    public bool aReached;
    public bool bReached;

    void Update()
    {
        float step = speed * Time.deltaTime;

        if (aReached == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObjectiveB.position, step);
        }

        if (bReached == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetObjectiveA.position, step);
        }

        if (transform.position == targetObjectiveA.position)
        {
            aReached = true;
            bReached = false;
        }

        if (transform.position == targetObjectiveB.position)
        {
            aReached = false;
            bReached = true;
        }
    }
}
