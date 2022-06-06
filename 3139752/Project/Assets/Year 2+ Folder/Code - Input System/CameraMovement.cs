using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    float rotationOnX;
    float mouseSensitivity = 90f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        //hide mouse cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Input
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime*mouseSensitivity;
        float m_X = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;

        //Up and down Camera
        rotationOnX -= mouseY;
        rotationOnX = Mathf.Clamp(rotationOnX, -90f, 90f);
        transform.localEulerAngles = new Vector3(rotationOnX, 0f, 0f);

        //Left to Right Camera
        player.Rotate(Vector3.up * m_X);
    }
}
