using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInput : MonoBehaviour
{
    public CharacterController Player;
    public GameObject CameraSystem;
    private bool CamUp;


    // Start is called before the first frame update
    void Start()
    {
        CamUp = false;
        CameraSystem.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CamUp == true)
            {
                CameraDown();
            }

            else
            {
                CameraUp();
            }
        }
    }

    public void CameraUp()
    {
        CameraSystem.SetActive(true);
        CamUp = true;
        Player.enabled = false;
    }

    public void CameraDown()
    {
        CameraSystem.SetActive(false);
        CamUp = false;
        Player.enabled = true;
    }

}
