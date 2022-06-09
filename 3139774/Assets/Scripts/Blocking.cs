using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocking : MonoBehaviour
{
    Animator anim;
    public CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Block",true);
        }
        else
            anim.SetBool("Block", false);
    }
}
