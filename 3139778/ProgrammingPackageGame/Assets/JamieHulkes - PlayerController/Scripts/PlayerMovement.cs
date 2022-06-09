using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody playerRb;

    public float speed = 6f;
    public bool movementEnabled = true;

    float horizontal;
    float vertical;

    Vector3 moveVector;
    [SerializeField] float lookSmoothing;

    [SerializeField] GameObject playerGFX;
    [SerializeField] Transform lookPoint;

    private GameManager gameManager;
    [SerializeField] GameObject dialogUI;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        playerRb = GetComponent<Rigidbody>();

        lookPoint.position = transform.position + playerGFX.transform.forward;
    }

    void Update()
    {
        if (movementEnabled)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            moveVector = new Vector3(horizontal, 0, vertical);

            PlayerLook();
        }
    }

    void FixedUpdate()
    {
        playerRb.AddForce(moveVector.normalized * speed, ForceMode.Acceleration);
    }

    void PlayerLook()
    {
        if (moveVector != Vector3.zero)
            lookPoint.position = moveVector.normalized + transform.position;

        Vector3 currentLook = transform.position + playerGFX.transform.forward;
        playerGFX.transform.LookAt(Vector3.Lerp(currentLook, lookPoint.position, lookSmoothing * Time.deltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            gameManager.coinsLeft--;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "mine")
        {
            Instantiate(dialogUI);
            Destroy(collision.gameObject);
        }
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("coin"))
        {
            Destroy(other.gameObject);
            gameManager.coinsLeft--;
        }

        if (other.CompareTag("mine"))
        {
            Destroy(other.gameObject);
            dialogUI.SetActive(true);
        }
    }
    */
}
