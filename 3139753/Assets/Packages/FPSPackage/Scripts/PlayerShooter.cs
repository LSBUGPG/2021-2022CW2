using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooter : MonoBehaviour
{
    //public float rotationSpeed;

    //Bullet speed
    public float bulletSpeed;

    //What will be fired
    public GameObject bullet;

    //Where the projectile will be fired
    public Transform gun;

    //This is how many seconds the player must wait before shooting
    private float BulletCooldown = 0;
    public float BulletCooldownWait = 3;



    // Update is called once per frame
    void Update()
    {
        //Shooting the actual bullet
        if (BulletCooldown > 0)
        {
            BulletCooldown -= 1 * Time.deltaTime;
        }



        //This creates the projectile 
        if (Input.GetKeyDown(KeyCode.Mouse0) && BulletCooldown <= 0 )
        {
            Debug.Log("Can shoot a bullet");
            BulletCooldown = BulletCooldownWait;
            GameObject b = Instantiate(bullet, gun.position, Quaternion.identity);
            Rigidbody rb = b.GetComponent<Rigidbody>();
            rb.AddForce(gun.transform.up * bulletSpeed, ForceMode.Impulse);

        }
    }
}
