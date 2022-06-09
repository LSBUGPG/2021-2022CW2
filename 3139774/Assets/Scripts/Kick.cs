using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    Animator anim;
    public CharacterController controller;
    public GameObject KickBall;


    // Start is called before the first frame update
    public void KickBallShow()
    {
        KickBall.SetActive(true);
    }
    public void KickBallHide()
    {
        KickBall.SetActive(false);
    }
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("Kick",true);
        }
        else
            anim.SetBool("Kick", false);
    }
}
