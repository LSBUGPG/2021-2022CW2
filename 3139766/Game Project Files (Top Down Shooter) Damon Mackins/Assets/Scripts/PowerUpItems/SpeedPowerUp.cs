using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedIncrease = 4f;
    public float effectDuration = 3f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Pickup());
        }
    }

    IEnumerator Pickup()
    {
        PlayerMovement.moveSpeed *= speedIncrease;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds(effectDuration);

        PlayerMovement.moveSpeed /= speedIncrease;

        Destroy(gameObject);
    }
}
