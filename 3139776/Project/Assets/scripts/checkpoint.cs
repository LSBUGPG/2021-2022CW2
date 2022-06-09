using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{

    public int CurrentCheckpoint;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<FirstPersonController>().SetCurrentCheckpoint(CurrentCheckpoint);
            
        }
    }
}
