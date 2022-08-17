using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float BulletSpd;

    float ForwardInput, HorizontalInput;
    [SerializeField] float ShootCooldown;
    float ShootDelay;

    [SerializeField] GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxisRaw("HorizontalAlt");
        ForwardInput = Input.GetAxisRaw("VerticalAlt");

        ShootDelay -= Time.deltaTime;
        
        if (HorizontalInput != 0 || ForwardInput != 0)
        {
            if (ShootDelay <= 0)
                Shoot();
        }        
    }

    void Shoot()
    {
        ShootDelay = ShootCooldown;

        Bullet NewBullet = Instantiate(Bullet, transform.position,Quaternion.identity).GetComponent<Bullet>();
        NewBullet.SetSpeed(HorizontalInput, ForwardInput, BulletSpd);

    }
}
