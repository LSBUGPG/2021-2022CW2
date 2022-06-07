using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasscodeButtons : Interactable
{
    
    static string correctCode = "1234";
    public static string playerCode = "";
    private static int totalDigits = 0;

    [SerializeField] private GameObject lockedDoor;
    private LockedDoor lockedDoorScript;

    [SerializeField] private GameObject PasscodeText;
    private DisplayPasscode displayPasscodeScript;

    private Outline outline;
    private bool canInteract = true;

    private void Start()
    {
        displayPasscodeScript = PasscodeText.GetComponent<DisplayPasscode>();
        correctCode = displayPasscodeScript.code.ToString();
        
        lockedDoorScript = lockedDoor.GetComponent<LockedDoor>();
        
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0f;
    }

 
    public override void OnFocus()
    {
        outline.OutlineWidth = 10f;
    }

    public override void OnInteract()
    {
        if (canInteract)
        {
            playerCode += gameObject.name;
            totalDigits += 1;
            Debug.Log(playerCode);

            if (totalDigits == 4)
            {
                if (playerCode == correctCode)
                {
                    StartCoroutine(PasscodeCorrect());
                }

                else
                {
                    StartCoroutine(PasscodeWrong());
                }
            }

            if (totalDigits > 4)
            {
                playerCode = playerCode.Remove(playerCode.Length - 1);
                totalDigits--;
            }
        }
    }

    public override void OnLoseFocus()
    {
        outline.OutlineWidth = 0f;
    }

    private IEnumerator PasscodeCorrect()
    {  
        playerCode = "Correct!";
        canInteract = false;
        lockedDoorScript.lockOpen = true;

        yield return new WaitForSeconds(2);
        
        totalDigits = 0;
        playerCode = "";
    }

    private IEnumerator PasscodeWrong()
    {
        playerCode = "Wrong!";
        canInteract = false;

        yield return new WaitForSeconds(1);
        
        playerCode = "";
        totalDigits = 0;
        canInteract = true;
    }
}
