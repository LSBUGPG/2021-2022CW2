using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

public class ThirdPersonMovement : MonoBehaviour
{

    public CharacterController controller;
    public Transform Cam;

    public float speed= 6f;
    public float turnsmoothtime = 0.1f;
    private float turnsmoothvelocity;
    public float jumphspeed = 1f;
    private float yspeed;
    private Vector3 movementDirection;
    private float velocity;
    private float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();



        yspeed += Physics.gravity.y * Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            yspeed = jumphspeed;
        }

        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;
        

        if (direction.magnitude>=0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg+Cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmoothvelocity,
                turnsmoothtime);
            var rotation = transform.rotation;
            rotation=Quaternion.Euler(0f,targetAngle,0f);
            rotation=Quaternion.Euler(0f,targetAngle,0f);
            transform.rotation = rotation;
             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir * speed * Time.deltaTime);
        }

        if (movementDirection!=Vector3.zero)
        {
            Quaternion toRotation=Quaternion.LookRotation(movementDirection,Vector3.up);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
      
    }

  
}
