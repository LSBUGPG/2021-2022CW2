using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : MonoBehaviour
{
    public float jumph;
    public float jumpforce;
    private Vector3 jump;
    private Rigidbody rigg;
    private bool isgrounded;
    private void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)&& isgrounded)
        {
            rigg.AddForce(jump, ForceMode.Impulse);
            isgrounded = false;
        }
        transform.Rotate(0, Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f, 0);
        transform.Translate(0, 0, Input.GetAxis("Vertical") * Time.deltaTime * 5.0f);
    }
}
