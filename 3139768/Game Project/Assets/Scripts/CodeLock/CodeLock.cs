using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CodeLock : MonoBehaviour
{
    // Attach this scrip to the pannel of the codelock

    int codeLength;
    int placeInCode;

    public string code = "";
    public string attemptedCode;

    public Transform toOpen;
    // use 'toOpen' as the object which this script effects.

    public GameObject LightBar;
    public Material defaultMaterial;
    public Material IncorrectMaterial;
    public Material CorrectMaterial;

    public bool CodeLockisACTIVE;
    public GameObject _theButton;
    public Animator _buttonanimator;

    public UnityEvent OpenDoor;

    private void Start()
    {
        codeLength = code.Length;
        CodeLockisACTIVE = false;
        _buttonanimator = _theButton.GetComponent<Animator>();
    }

    void CheckCode()
    {
        if (attemptedCode == code)
        {
            StartCoroutine(Open());
            //Add something to show the code is correct
            LightBar.GetComponent<Renderer>().material = CorrectMaterial;
        }
        else
        {
            StartCoroutine(WrongCode());
            Debug.Log("Wrong Code");
            //Add something to show the code incorrect
            LightBar.GetComponent<Renderer>().material = IncorrectMaterial;
        }
    }

    IEnumerator Open()
    {
        //this is if the code is input correctly

        CodeLockisACTIVE = true;

        //toOpen.Rotate(new Vector3(0, 90, 0), Space.World);
        //_buttonanimator.SetBool("DoorOpen", true);
        OpenDoor.Invoke();

        yield return new WaitForSeconds(4);

        //toOpen.Rotate(new Vector3(0, -90, 0), Space.World);
        // Having this twice opens the door then closes it after 4 seconds. 
        //'toOpen... Space.World);' is responsible for rotating the object in the back of scene
        //it can changed to have a different result. There are 2 lines, the one after 'waitforseconds' 
        //has to wait before running, it also rotates it back into the start position. 
    }

    IEnumerator WrongCode()
    {
        //this is if the code is input incorrectly

        yield return new WaitForSeconds(1);
        //The time it takes before switching the red lightbar back to its original material
        LightBar.GetComponent<Renderer>().material = defaultMaterial;
        //^ the lightbar object
    }



    public void SetValue (string value)
    {
        placeInCode++;

        if (placeInCode <= codeLength)
        {
            attemptedCode += value; 
        }

        if (placeInCode == codeLength)
        {
            CheckCode();

            attemptedCode = "";
            placeInCode = 0;
        }
    }
}
