using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractOpen : MonoBehaviour
{
    public Animator _animator;
    public bool _inrange;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _inrange = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _inrange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            _inrange = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _inrange)
            _animator.SetBool("PlayerOpen", true);
    }
}
