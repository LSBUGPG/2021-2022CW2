using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float RotationSpeed = 10;

    private void OnMouseDrag()
    {
        float Xdirection = Input.GetAxis("Mouse X") * RotationSpeed;
        float Ydirection = Input.GetAxis("Mouse Y") * RotationSpeed;

        transform.Rotate(Vector3.up, Xdirection);
        transform.Rotate(Vector3.right, Ydirection);
    }

}