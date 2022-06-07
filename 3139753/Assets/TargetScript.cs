using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{

    public GameObject ParticleFlare;
    public float Timer = 5;
    private float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown < Timer)
        {
            countdown += 1 * Time.deltaTime;
        }

        if(countdown >= Timer)
        {
            Debug.Log("Disable");
            Disable();
        }
    }

    void OnTriggerEnter(Collider Trigger)
    {
        //If anything other than the player is touched then the object will be destroyed
        if (Trigger.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            Hit();
        }


    }
    private void Hit()
    {
        countdown = 0;
        ParticleFlare.SetActive(true);
    }

    private void Disable()
    {
        ParticleFlare.SetActive(false);
    }
}
