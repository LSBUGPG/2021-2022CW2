using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public float throwForce = 600;
    Vector3 objectPos;
    float distance;

    public bool canHold = true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding = false;
    void Update()
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (isHolding)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Throw");
                isHolding = false;
                rb.useGravity = true;
                rb.isKinematic = false;
                item.transform.SetParent(null);
                rb.AddForce(tempParent.transform.forward * throwForce, ForceMode.Impulse);
            }
        }
        else
        {
            distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
            if (distance < 1f && Input.GetMouseButtonDown(0))
            {
                Debug.Log("PickUp");
                isHolding = true;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.useGravity = false;
                rb.isKinematic = true;
                item.transform.SetParent(tempParent.transform);
            }
        }
        /*
        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 1f)
        {
            isHolding = false;
        }

        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            if (Input.GetMouseButtonDown(0))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }

            else
            {
                objectPos = item.transform.position;
                item.transform.SetParent(null);
                item.GetComponent<Rigidbody>().useGravity = true;
                item.transform.position = objectPos;
            }
        }*/
    }

/*    void OnMouseDown()
    {
        if (distance <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;
        }
    }

     void OnMouseUp()
    {
        isHolding = false;
    }*/
}
