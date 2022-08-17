using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementScript : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 20;
    Vector2 velocity;
    private void FixedUpdate()
    {
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Rotate(0, velocity.x * rotateSpeed * 100 * Time.deltaTime, 0);
        transform.Translate(0, 0, velocity.y * speed * Time.deltaTime);
    }
}
