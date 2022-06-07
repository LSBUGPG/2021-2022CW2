using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimated : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void OpenDoor() {
        animator.SetBool("IsOpen", true);
    }

    public void CloseDoor() {
        animator.SetBool("IsOpen", false);
    }

}
