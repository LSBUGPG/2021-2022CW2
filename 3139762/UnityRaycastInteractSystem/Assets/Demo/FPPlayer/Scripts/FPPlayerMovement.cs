using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPPlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float walkSpeed = 2f;
    [SerializeField] float runSpeed = 6f;
    [SerializeField] float speedSmoothTime = 0.1f;
    [SerializeField] float jumpForce = 7.5f;
    [SerializeField] float jumpTimeout = .3f;
    float targetMove, targetStrafe;

    [Header("Player Grounded")]
    [Tooltip("Ground Check Sphere height offset")]
    [SerializeField] float GroundedOffset = -0.14f;
    [Tooltip("The radius of the grounded check")]
    [SerializeField] float GroundedRadius = 0.28f;
    [Tooltip("What layers the character uses as ground")]
    [SerializeField] LayerMask GroundLayers;

    [Header("Falling Properties")]
    [SerializeField] float extraFallingForce = 2;
    [SerializeField] float maxFallingSpeed = 100;
    [SerializeField] float fallingAnimationTimeout = .15f;

    public bool overrideMovement = false;
    public bool overrideFalling = false;
    public bool grounded { get; private set; }
    public float targetSpeed { get; private set; }

    float moveSmoothVelocity, strafeSmoothVelocity;

    float jumpTimeoutDelta;

    Rigidbody rb;
    FPPlayerInput _input;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _input = GetComponent<FPPlayerInput>();
    }
    void Start()
    {
        jumpTimeoutDelta = jumpTimeout;
    }
    private void Update()
    {
        GroundCheck();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        PlayerJump();
        Falling();
    }
    void MovePlayer()
    {
        if (!overrideMovement)
        {
            float inputSpeed = (_input.sprintPressed ? runSpeed : walkSpeed) * _input.moveDir.magnitude;

            float inputMove = _input.moveDir.y * inputSpeed;
            targetMove = Mathf.SmoothDamp(targetMove, inputMove, ref moveSmoothVelocity, speedSmoothTime);
            float inputStrafe = _input.moveDir.x * inputSpeed;
            targetStrafe = Mathf.SmoothDamp(targetStrafe, inputStrafe, ref strafeSmoothVelocity, speedSmoothTime);
            float xVel = (transform.forward.x * targetMove) + (transform.right.x * targetStrafe), zVel = (transform.forward.z * targetMove) + (transform.right.z * targetStrafe);

            rb.velocity = new Vector3(xVel, rb.velocity.y, zVel);
        }
    }
    void PlayerJump()
    {
        if (grounded)
        {
            if (_input.jumpPressed)
            {
                if (jumpTimeoutDelta <= 0)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
                    jumpTimeoutDelta = jumpTimeout;

                }
            }
            if (jumpTimeoutDelta > 0)
            {
                jumpTimeoutDelta -= Time.fixedDeltaTime;
            }
        }
        /*else
        {
            _input.jumpPressed = false;
        }*/
    }
    void Falling()
    {
        if (rb.velocity.y < -.5f && !overrideFalling)
        {
            if (rb.velocity.y > -Mathf.Abs(maxFallingSpeed))
            {
                //Debug.Log("Adding extra falling force");
                rb.AddForce(Vector3.down * extraFallingForce);
            }
            else if (rb.velocity.y < -Mathf.Abs(maxFallingSpeed))
            {
                //Debug.Log("Falling to fast");
                rb.velocity = new Vector3(rb.velocity.x, maxFallingSpeed, rb.velocity.z);
            }
        }
    }
    private void GroundCheck()
    {
        // set sphere position, with offset
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z);
        grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers, QueryTriggerInteraction.Ignore);
    }
    private void OnDrawGizmosSelected()
    {
        Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        if (grounded) Gizmos.color = transparentGreen;
        else Gizmos.color = transparentRed;

        // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z), GroundedRadius);
    }
}
