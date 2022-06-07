using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnCollisionEnter(Collision Collision)
    {
        //If anything other than the player is touched then the object will be destroyed
        if (Collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }

    }
}
