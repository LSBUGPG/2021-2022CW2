using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTayoTrackerFront : MonoBehaviour
{

    public GameObject Katayo;

    [HideInInspector]
    public bool Playerfront = false;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Playerfront = true;
            Katayo.GetComponent<katayoAI>().SetNewDestinationfront(); 
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Playerfront = false;
            
        }

    }
}
