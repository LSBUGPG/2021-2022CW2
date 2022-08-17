using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueCall : MonoBehaviour
{
    public LayerMask raycastMask;
    public float lookRange;

    // Update is called once per frame
    void Update()
    {
        // Gets input from the E key in order to start a conversation with an NPC
        if (Input.GetKeyDown(KeyCode.E))
        {
            // We use a raycast hit to temporarily save components such as the object hit, the position of hit
            RaycastHit hit;
            // Creates the raycast from the position of the camera in a forward direction
            // Uses hit variable to target the hit object, the range of the raycast and layer the raycast is on
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, lookRange, raycastMask))
            {
                // Checks if the hit object is tagged as an NPC
                if (hit.transform.tag == "NPC")
                {
                    // If it is an NPC, we run the 'Start Dialogue' function from the EnableDialogue Script
                    hit.transform.GetComponent<EnableDialogue>().StartDialogue();
                }
            }
        }
    }
}
