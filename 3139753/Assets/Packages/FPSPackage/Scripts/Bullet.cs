using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        //After three seconds the object will destory itself
        Destroy(this.gameObject, 3);
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
