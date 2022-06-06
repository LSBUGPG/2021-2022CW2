using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehaviour : MonoBehaviour
{
    public Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            _animator.SetBool("Playeropen", true);
    }
}