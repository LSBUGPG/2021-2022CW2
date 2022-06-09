using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("PlayerHealth")]
    public Image healthBar;
    public float currentHealth; 
    public int maxHealth;
    //private float currentHealth;
    [SerializeField] private Transform canvasTransform;

    

    [Header("PlayerMovement")]
    public CharacterController controller;
    public float speed = 15f;
    public float gravity = -12f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;
    bool isGrounded;

    private float KeyCount;
    public float TotalKeys;
    public Text KeyTracker;

    Vector3 velocity;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        //currentHealth = maxHealth;
    }

    

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        //currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        // HealthBar.value = currentHealth;
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;
        UpdateHealthBar();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "heal")
        {
            HealDamage(10);
            Destroy(other.gameObject);
        }

       if (other.gameObject.tag == "damage")
        {
           TakeDamage(10);
            UpdateHealthBar();
        }

        if (other.gameObject.tag == "key")
        {
            KeyCount++;
            KeyTracker.text = "KEY COUNT: " + KeyCount.ToString() + "/" + TotalKeys.ToString();
            Destroy(other.gameObject);

            if (KeyCount >= TotalKeys)
            {
                Cursor.lockState = CursorLockMode.Confined;
                SceneManager.LoadScene(4);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
    }

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(3);
        UnityEngine.Debug.Log("Dead");

    }


}
