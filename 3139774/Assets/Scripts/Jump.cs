using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody rb;
    public bool Grounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& Grounded)
        {
            rb.AddForce(new Vector3(0,5,0),ForceMode.Impulse);
            Grounded = false;
        }
        
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Ground")
        {
            Grounded = true;
        }
    }
}
