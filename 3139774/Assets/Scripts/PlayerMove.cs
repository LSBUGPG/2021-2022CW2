using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    float ForwardInput, HorizontalInput;
    [SerializeField] float Spd;
    Vector3 MoveVector;
    [Space]
    [SerializeField] Transform Maincam;
    [Header("Jump")]
    [SerializeField] LayerMask GroundLayer;
    [SerializeField] Transform GroundCheck;
    [SerializeField] float CheckRadius = 0.2f;
    [SerializeField] int JumpCount;
    [SerializeField] float JumpHeight;
    bool IsGrounded;
    int JumpsRemaining;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
        RotatePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    //CONTROLS FOR THE PLAYER
    void PlayerInput()
    {
        ForwardInput = Input.GetAxisRaw("Vertical");
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        MoveVector = (transform.right * HorizontalInput) + (transform.forward * ForwardInput);
    }

    void Jump()
    {
        float VelocityY;
        IsGrounded = Physics.CheckSphere(GroundCheck.position, CheckRadius, GroundLayer);

        if (IsGrounded)
            JumpsRemaining = JumpCount;

        if (JumpsRemaining > 0)
        {
            JumpsRemaining--;

            VelocityY = Mathf.Sqrt(-2 * Physics.gravity.y * JumpHeight);
            rb.velocity = new Vector3(rb.velocity.x, VelocityY, rb.velocity.z);
        }

     
    }


    void RotatePlayer()
    {
        transform.eulerAngles = new Vector3(0, Maincam.transform.eulerAngles.y);

        
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector3(MoveVector.x * Spd, rb.velocity.y, MoveVector.z * Spd);
    }
}
