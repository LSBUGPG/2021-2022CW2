using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //NOTE: This is an original script enables the mouse to maintain its function between scenes.
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
