using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{

    [SerializeField] BoxCollider DoorCollider;
    [SerializeField] Rigidbody DoorRB;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            DoorCollider.enabled = false;
            DoorRB.isKinematic = false;
        }
    }
}
