using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraNavigation : MonoBehaviour
{

    //Allows the player to assign how many cameras they want
    private int SelectedCamera = 0;

    public RawImage CameraScreen;

    // Set the materials in the inspector
    public Material[] Cameras;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (SelectedCamera >= Cameras.Length)
        {
            SelectedCamera = 0;
        }

        if (SelectedCamera < 0)
        {
            SelectedCamera = Cameras.Length - 1;
        }

        CameraScreen.material = Cameras[SelectedCamera];

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Forward();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Back();
        }
    }

    public void Back()
    {
        SelectedCamera = SelectedCamera - 1;
    }

    public void Forward()
    {
        SelectedCamera = SelectedCamera + 1;
    }
}
