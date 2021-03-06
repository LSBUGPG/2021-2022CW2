using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Verical");
        Vector3 direction = new Vector3(horizontal, 0f, Vertical).normalized;

        if (direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            controller.Move(direction * speed * Time.deltaTime);
        }
    }
}
