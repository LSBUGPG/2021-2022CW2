using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAndShrink : MonoBehaviour
{
    public Rigidbody rb;
  


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var s = rb.transform.localScale;


        //small
        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }


        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
