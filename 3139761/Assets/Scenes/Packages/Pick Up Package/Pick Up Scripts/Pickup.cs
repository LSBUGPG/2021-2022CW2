using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public Transform player;
    bool touching;
    Vector3 offset = new Vector3(2f, 0.5f, -6.3f);
    // Start is called before the first frame update
    void Update()
    {
        if (touching && Input.GetKeyDown(KeyCode.E))
        {
            transform.SetParent(player);
            transform.position = player.position + offset;
            //transform.localPosition = new Vector3(1.089f , 0.287f , -2.570067f );
            //transform.position = new Vector3(0f,0f,0f);
            // transform.localRotation = Quaternion.Euler(Vector3.zero);
        }
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            touching = false;
        }
    }



}
