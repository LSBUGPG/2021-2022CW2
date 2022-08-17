using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDialogue : MonoBehaviour
{

    private CharacterController Disabled;
    private CameraController Disabled2;
    public GameObject DialogueBox,Dialgue2;
    public static bool enabledSecondDialogue;
    public static int capsuleProgress;
    public int dialoguesToGoThrough;
    // Start is called before the first frame update
    void Start()
    {
        // Finds an object with the character controller script in the scene
        Disabled = Object.FindObjectOfType<CharacterController>();
        // Finds an object with the camera controller script in the scene
        Disabled2 = Object.FindObjectOfType<CameraController>();
    }

    // function to enable the dialogue window called from the DialogueCall script
    public void StartDialogue()
    {
        // enables the dialogue box
        DialogueBox.SetActive(true);
        // checks if the Capsule progress is more or equal to the needed number of people you're dating when talking to him
        if (capsuleProgress >= dialoguesToGoThrough)
        {
            // checks if we have assigned the second dialogue to the Capsule object
            if (Dialgue2)
            {
                // disables the first dialogue box
                DialogueBox.GetComponent<DialogueUI>().enabled = false;
                // enables the bool for the Capsule's date time dialogue
                enabledSecondDialogue = true;
                // enables the dating time dialogue box
                Dialgue2.SetActive(true);
            }           
        }
        
        

        // character controller is disabled
        Disabled.enabled = false;
        // camera controller is disabled
        Disabled2.enabled = false;
        // hides the mouse in game
        Cursor.visible = true;
        // locks the mouse inside the game window
        Cursor.lockState = CursorLockMode.None;
    }
}
