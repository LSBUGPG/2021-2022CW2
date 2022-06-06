using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCollection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ScoreScript.theScore += 50;
        Destroy(gameObject);
    }

    

}
