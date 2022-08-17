using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // creates rigid body in the code
    private Rigidbody rB;
    // creates a speed variable
    public float speeeeeeeed;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigid body from this game object
        rB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // call the movement function
        Move();
    }

    private void Move()
    {
        // get input from W and S
        float inputZ = Input.GetAxisRaw("Vertical");
        // get input from A and D
        float inputX = Input.GetAxisRaw("Horizontal");

        // creates movement along the Z axis
        Vector3 forwardMovement = (transform.forward * inputZ);
        // creates movement along the X axis
        Vector3 sidewaysMovement = (transform.right * inputX);

        // blends both Z and X vectors and clamp it between 1 and -1
        Vector3 normalisedMovement = (forwardMovement + sidewaysMovement).normalized;


        // adds velocity to the rigid body on X and Z axis
        rB.velocity = new Vector3(normalisedMovement.x * speeeeeeeed, rB.velocity.y, normalisedMovement.z * speeeeeeeed);
    }
}
