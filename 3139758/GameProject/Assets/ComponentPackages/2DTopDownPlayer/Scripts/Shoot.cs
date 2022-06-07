using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Shooting();
        }
    }

    void Shooting()
    {
        if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastVertical") > 0.01)
        {
            animator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<Animator>().SetFloat("lastVertical", 1);
            rb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
        }

        if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastVertical") < -0.01)
        {
            animator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<Animator>().SetFloat("lastVertical", -1);
            rb.AddForce(-firePointDown.up * bulletForce, ForceMode2D.Impulse);
        }

        if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastHorizontal") < -0.01)
        {
            animator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<Animator>().SetFloat("lastHorizontal", -1);
            rb.AddForce(-firePointLeft.right * bulletForce, ForceMode2D.Impulse);
        }

        if (gameObject.GetComponent<PlayerMovement>().animator.GetFloat("lastHorizontal") > 0.01)
        {
            animator.SetTrigger("Shoot");
            GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.GetComponent<Animator>().SetFloat("lastHorizontal", 1);
            rb.AddForce(firePointRight.right * bulletForce, ForceMode2D.Impulse);
        }
    }
}
