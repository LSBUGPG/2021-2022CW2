using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedDoor : MonoBehaviour
{
    public bool lockOpen;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        lockOpen = false;
    }

    private void Update()
    {
        anim.SetBool("lockOpen", lockOpen);
    }
}
