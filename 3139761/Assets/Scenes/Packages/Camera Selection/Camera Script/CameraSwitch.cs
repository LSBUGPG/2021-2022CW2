using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public GameObject View2D;
    public GameObject View3D;
    public GameObject Top;
    public GameObject Side;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            View2D.SetActive(true);

            View3D.SetActive(false);

            Top.SetActive(false);

            Side.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            View3D.SetActive(true);

            View2D.SetActive(false);

            Top.SetActive(false);

            Side.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            View3D.SetActive(false);

            View2D.SetActive(false);

            Top.SetActive(true);

            Side.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            View3D.SetActive(false);

            View2D.SetActive(false);

            Top.SetActive(false);

            Side.SetActive(true);
        }
    }
}
