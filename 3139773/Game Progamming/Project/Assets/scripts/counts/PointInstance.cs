using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInstance : MonoBehaviour
{
    public 
    void OnTriggerEnter(Collider other)
    {
        scoreManger.theScore += 1;
        Destroy(gameObject);
    }
}
