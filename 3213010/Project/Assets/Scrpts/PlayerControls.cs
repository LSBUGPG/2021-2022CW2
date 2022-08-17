using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControls : MonoBehaviour
{

    Rigidbody RB;
    float ForwardInput, HorizontalInput;
    [SerializeField] float speed;


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        ForwardInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector3 Direction = new Vector3(HorizontalInput, 0, ForwardInput).normalized;

        RB.velocity = (Direction * speed);
    }
}
