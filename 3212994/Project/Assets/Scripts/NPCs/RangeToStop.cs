using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeToStop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // stops the npc from moving if the player interacts with the NPC collider
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<NpcMovement>().StopCoroutines();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // continues each npc's movement cycle if the player is out of range of the collider
        if (other.tag == "Player")
        {
            gameObject.GetComponentInParent<NpcMovement>().StartCoroutines();
        }
    }
}
