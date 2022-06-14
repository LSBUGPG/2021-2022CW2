using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    public Transform cam;

    private float xInput;
    private float yInput;

    private float normalSpeed;
    public float boostedSpeed;
    public float speedCooldown;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        normalSpeed = moveSpeed;
    }

    void Update()
    {
        ProcessInputs();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput, 0f, yInput) * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag ("SpeedBoost"))
        {
            moveSpeed = boostedSpeed;
            StartCoroutine("speedDuration");
        }

        if (other.CompareTag("Teleporter"))
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.position = other.GetComponent<TeleportPosition>().teleportLocation.position;
        }
    }
    IEnumerator speedDuration()
    {
        yield return new WaitForSeconds(speedCooldown);
        moveSpeed = normalSpeed;
    }
}
