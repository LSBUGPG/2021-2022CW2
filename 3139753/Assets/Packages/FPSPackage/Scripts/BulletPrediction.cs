using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletPrediction : MonoBehaviour
{

    //All the junk for the trajectory trail
    private float DestroyCooldown = 1;

    // Update is called once per frame
    void Update()
    {
    //Shooting the faint bullet that will predict the actual bullet movement
        if (DestroyCooldown > 0)
        {
            DestroyCooldown -= 1 * Time.deltaTime;
        }

        if (DestroyCooldown <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision Collision)
    {
        //If anything other than the player is touched then the object will be destroyed
        if (Collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }


    }
}
