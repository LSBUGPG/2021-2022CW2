using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    public float health;
    public Slider slider;
    public Transform respawn;
    public Transform Death;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
        if (health <= 0)
        {
            health = 100f;
            transform.position = respawn.position;
        }
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.gameObject.tag == "Enemy")
	    {
            health = health - 20f;
            Debug.Log("hit Player");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            health = 0;
        }
    }
}
