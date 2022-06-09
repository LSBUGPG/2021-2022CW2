using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    public int ID;
   // public katayoAI player;
    public GameObject Katayo;
    MazeTayoTrackerFront trackerFront;
    private void Start()
    {
        trackerFront = FindObjectOfType<MazeTayoTrackerFront>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Katayo"))
        {
            print("checkpoint reached");
            Invoke("DirectKatayo", 2f);
            
           
        }
    }

    void DirectKatayo()
    {
        if (trackerFront.Playerfront)
        {
            Katayo.GetComponent<katayoAI>().SetNewDestinationfront();
            print("newwaypointfront");
        }
        else
            Katayo.GetComponent<katayoAI>().SetNewDestinationback();

    }

    
}
