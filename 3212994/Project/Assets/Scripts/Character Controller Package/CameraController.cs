using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    Vector2 mouseLook;
    Vector2 smoothness;

    public float mouseSense;
    public float smoothing;

    GameObject character;

    // Start is called before the first frame update
    void Start()
    {
        // access the parent of the camera (the character)
        character = this.transform.parent.gameObject;
        // hides the mouse in game
        Cursor.visible = false;
        // locks the mouse inside the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // we get the X and Y input from the mouse
        var mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // we multiply it by the sensitivity and smoothing
        mouseInput = Vector2.Scale(mouseInput, new Vector2(mouseSense * smoothing, mouseSense * smoothing));
        // lerping the x of our smoothness vector between x input and smoothing value 
        smoothness.x = Mathf.Lerp(smoothness.x, mouseInput.x, 1 / smoothing);
        // lerping the y of our smoothness vector between y input and smoothing value 
        smoothness.y = Mathf.Lerp(smoothness.y, mouseInput.y, 1 / smoothing);

        // adds our smoothenss vector to our movement vector for the camera
        mouseLook += smoothness;
        // clamp the y value of the vector so the camera doesn't overturn when looking up or down
        mouseLook.y = Mathf.Clamp(mouseLook.y, -85, 85);

        // we rotate the camera on y with our mouseLook vector
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
        // we rotate the character on x with our mouseLook vector
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
    }
}
