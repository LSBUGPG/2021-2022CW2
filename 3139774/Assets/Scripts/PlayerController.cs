using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody RB;
    public float Jumpforce;
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,RB.velocity.y,Input.GetAxis("Vertical")*moveSpeed);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.velocity = new Vector3(RB.velocity.x, Jumpforce, RB.velocity.z);
        }
    }
}
 