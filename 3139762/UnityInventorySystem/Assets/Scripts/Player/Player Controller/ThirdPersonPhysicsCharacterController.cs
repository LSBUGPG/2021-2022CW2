using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPhysicsCharacterController : MonoBehaviour
{
    Rigidbody rb;
    CapsuleCollider col;
    ThirdPersonInput pInput;
    CharacterAnimationCtrl animClass;
    bool hasAnimClass;
    PlayerInteract pInteract;
    bool hasInteractClass;

    [Header("Movement Speed Properties")]
    [SerializeField] float walkSpeed = 2;
    [SerializeField] float runSpeed = 5;

    [Header("Step Properties")]
    [SerializeField] float stepLowerRayHeight = .05f;
    [SerializeField] float stepLowerDetectionDist = .1f;
    [SerializeField] float maxStepHeight = .3f;
    [SerializeField] float stepClearDetectionDist = .2f;
    [SerializeField] float stepUpSmooth = .1f;

    [Header("Smoothing Properties")]
    [SerializeField] float turnSmoothTime = 0.2f;
    [SerializeField] float speedSmoothTime = 0.1f;

    [Header("Crouch Properties")]
    [SerializeField] [Tooltip("New collider height on character crouch")] float crouchHeight = 1;
    [SerializeField] [Tooltip("New Center point for the character's collider on crouch")] Vector3 crouchCenter = new Vector3(0, .5f);
    [SerializeField] float crouchSmoothTime = .1f;
    bool isCrouching;
    public bool IsCrouching { get { return isCrouching; } }

    [Header("Ground Check Properties")]
    [SerializeField] private float groundCheckRadius = .28f;
    [SerializeField] private float groundCheckOffset = -.15f;
    [SerializeField] private LayerMask groundLayers;

    [Header("Jump Force Properties")]
    [SerializeField] float jumpForce = 5;
    [SerializeField] float jumpTimeout = .3f;

    [Header("Falling Properties")]
    [SerializeField] float extraFallingForce = 2;
    [SerializeField] float maxFallingSpeed = 100;
    [SerializeField] float fallingAnimationTimeout = .15f;

    float targetSpeed;
    Transform camT;
    float turnSmoothVelocity;
    float speedSmoothVelocity;

    float jumpTimeoutDelta;
    float fallAnimTimeoutDelta;

    float defaultColHeight;
    Vector3 defaultColCenter;

    float colHeightSmoothVel;
    Vector3 colCenterSmoothVel;
    float targetCrouchBlend, crouchBlendSmoothVel;

    [HideInInspector] public bool overrideMovement = false;
    [HideInInspector] public bool overrideFalling = false;
    [HideInInspector] public bool jumped = false;
    void Awake()
    {
        animClass = GetComponent<CharacterAnimationCtrl>();
        hasAnimClass = animClass != null ? true : false;
        pInteract = GetComponent<PlayerInteract>();
        hasInteractClass = pInteract != null ? true : false;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        pInput = GetComponent<ThirdPersonInput>();
        camT = Camera.main.transform;

        defaultColHeight = col.height;
        defaultColCenter = col.center;
    }
    private void Start()
    {
        jumpTimeoutDelta = jumpTimeout;
    }
    private void Update()
    {
        Interact();
    }
    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
        PlayerCrouch();
        PlayerJump();
        Falling();
        animClass.SetGrounded(IsGrounded());
        
    }
    void RotatePlayer()
    {
        if (pInput.MovementDir() != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(pInput.MovementDir().x, pInput.MovementDir().y) * Mathf.Rad2Deg + camT.eulerAngles.y;
            rb.rotation = Quaternion.Euler(Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime));
        }
    }
    void MovePlayer()
    {
        float inputSpeed = (isCrouching ? walkSpeed : ((pInput.SprintPressed()) ? runSpeed : walkSpeed)) * pInput.MovementDir().magnitude;
        targetSpeed = Mathf.SmoothDamp(targetSpeed, inputSpeed, ref speedSmoothVelocity, speedSmoothTime);

        if (hasAnimClass) animClass.SetSpeed(targetSpeed);

        if (!overrideMovement) rb.velocity = new Vector3(transform.forward.x * targetSpeed, rb.velocity.y, transform.forward.z * targetSpeed);
        if (targetSpeed > 0.5f) Step();
    }
    void Step()
    {
        RaycastHit hitLower;
        if(Physics.Raycast(transform.position + new Vector3(0, stepLowerRayHeight,0), transform.forward, out hitLower, stepLowerDetectionDist)){
            RaycastHit hitUpper;
            if(!Physics.Raycast(transform.position + new Vector3(0, maxStepHeight, 0), transform.forward, out hitUpper, stepClearDetectionDist))
            {
                rb.position += new Vector3(0, stepUpSmooth, 0);
                Debug.Log("Stepping up");
            }
        }
        RaycastHit hitLower45;
        if (Physics.Raycast(transform.position + new Vector3(0, stepLowerRayHeight, 0), transform.TransformDirection(1.5f,0,1), out hitLower45, stepLowerDetectionDist))
        {
            RaycastHit hitUpper45;
            if (!Physics.Raycast(transform.position + new Vector3(0, maxStepHeight, 0), transform.TransformDirection(1.5f, 0, 1), out hitUpper45, stepClearDetectionDist))
            {
                rb.position += new Vector3(0, stepUpSmooth, 0);
                Debug.Log("Stepping up 45");
            }
            RaycastHit hitLowerMinus45;
            if (Physics.Raycast(transform.position + new Vector3(0, stepLowerRayHeight, 0), transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, stepLowerDetectionDist))
            {
                RaycastHit hitUpperMinus45;
                if (!Physics.Raycast(transform.position + new Vector3(0, maxStepHeight, 0), transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, stepClearDetectionDist))
                {
                    rb.position += new Vector3(0, stepUpSmooth, 0);
                    Debug.Log("Stepping up -45");
                }
            }
        }
    }
    void PlayerCrouch()
    {
        if (IsGrounded())
        {
            if (pInput.CrouchPressed())
            {
                isCrouching = true;
            }
            else isCrouching = false;
        }
        else isCrouching = false;

        col.height = Mathf.SmoothDamp(col.height, isCrouching ? crouchHeight : defaultColHeight, ref colHeightSmoothVel, crouchSmoothTime);
        col.center = Vector3.SmoothDamp(col.center, isCrouching ? crouchCenter : defaultColCenter, ref colCenterSmoothVel, crouchSmoothTime);

        if (hasAnimClass) {
            targetCrouchBlend = Mathf.SmoothDamp(targetCrouchBlend, isCrouching ? -1 : 0, ref crouchBlendSmoothVel, crouchSmoothTime);
            animClass.SetCrouch(targetCrouchBlend);
        } 
    }
    void PlayerJump()
    {
        if (IsGrounded())
        {
            fallAnimTimeoutDelta = fallingAnimationTimeout;
            if (hasAnimClass) animClass.SetFalling(false);

            if (pInput.JumpPressed())
            {
                if (jumpTimeoutDelta < 0)
                {
                    rb.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
                    jumped = true;
                    Debug.Log("Jumped: " + jumped);
                    jumpTimeoutDelta = jumpTimeout;
                    if (hasAnimClass)
                    {
                        animClass.Jump();
                    }

                }
            }
            if (jumpTimeoutDelta > 0)
            {
                jumpTimeoutDelta -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (jumpTimeoutDelta > 0)
            {
                jumpTimeoutDelta -= Time.fixedDeltaTime;
            }
            else
            {
                if (hasAnimClass)
                {
                    animClass.SetFalling(true);
                }
            }
        }
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
    public bool IsGrounded()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundCheckOffset, transform.position.z);
        return Physics.CheckSphere(spherePosition, groundCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);
    }
    void Interact()
    {
        if (hasInteractClass)
        {
            if (pInput.InteractPressed()) pInteract.Interact();
        }
    }
    private void OnDrawGizmos()
    {
        Color green = new Color(0.0f, 1.0f, 0.0f, 0.35f);
        Color red = new Color(1.0f, 0.0f, 0.0f, 0.35f);

        //Ground Check
        if (IsGrounded()) Gizmos.color = green;
        else Gizmos.color = red;

        Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - groundCheckOffset, transform.position.z), groundCheckRadius);

        //Step Rays
        Gizmos.color = red;
        Gizmos.DrawRay(transform.position + new Vector3(0, stepLowerRayHeight), transform.TransformDirection(Vector3.forward) * stepLowerDetectionDist);
        Gizmos.DrawRay(transform.position + new Vector3(0, maxStepHeight), transform.TransformDirection(Vector3.forward) * stepClearDetectionDist);
    }
}
