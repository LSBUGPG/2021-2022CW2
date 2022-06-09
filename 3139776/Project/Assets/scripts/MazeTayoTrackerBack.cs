using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeTayoTrackerBack : MonoBehaviour
{
    public GameObject Katayo;

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
            Katayo.GetComponent<katayoAI>().SetNewDestinationback();
        }
       
    }

}
