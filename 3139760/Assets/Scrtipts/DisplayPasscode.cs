using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPasscode : MonoBehaviour
{
    [SerializeField] public int code;
    
    void Start()
    {
          
    }

    
    void Update()
    {
        GetComponent<TextMesh>().text = PasscodeButtons.playerCode;
    }
}
