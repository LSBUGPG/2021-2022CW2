using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCwave : MonoBehaviour
{
    public Animator _animator;
    public GameObject _NPCtext;

    private void Start()
    {
        _animator = GetComponent<Animator>(); //set the animator object so we can access the parameters
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")  //check if it's the player entering the trigger area
        {
            _animator.SetBool("PlayerNearby", true); //tell the state machine to do something

            if (Input.GetKeyDown(KeyCode.F))
            {
                _NPCtext.SetActive(true); //show the NPC text box - drag into Inspector from Hierarchy
                _animator.SetBool("Talk", true);
            }
            _animator.SetBool("StopAnimation", false);  //resets the state machine in-case player leaves & re-enters
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _animator.SetBool("Talk", false);
            _animator.SetBool("PlayerNearby", false);  //tell the state machine not to do something
            _animator.SetBool("StopAnimation", true);  //tell the state machine to do something
            _NPCtext.SetActive(false); //disable the text box
        }
    }
}