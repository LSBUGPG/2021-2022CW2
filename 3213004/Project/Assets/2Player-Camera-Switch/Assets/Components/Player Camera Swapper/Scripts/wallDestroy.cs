using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallDestroy : MonoBehaviour
{
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(wall);
        
    }
}
