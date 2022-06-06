using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anim : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {

    }

    private void Update()
    {

        if (Input.GetKey(KeyCode.W)) // key to direction
        {
            //animator.Play("Fast Run"); // state name
            Debug.Log("IT'S RUNNING"); // you know
            animator.SetBool("Run", true); //bool for the movement (parameter)
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            animator.SetBool("Run", false);
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Jumping");
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animator.SetBool("Jump", false);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("BackWalk");
            animator.SetBool("Back Walk", true);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Back Walk", false);
        }
    }
}
