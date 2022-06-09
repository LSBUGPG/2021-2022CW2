using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other)
    {
      ScoringSystem1.theScore += 1;
      Destroy(gameObject);
    }
}
