using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabListener : MonoBehaviour
{
    public Transform finalPosition;
    public float speed = 2f;
    public float rotSpeed = 10f;

    Vector3 originalPosition;
    Quaternion originalRotation;
    GameObject _objectGrabbed;

    public void ObjectGrabbed(GameObject objectGrabbed)
    {
        this._objectGrabbed = objectGrabbed;

        this.originalPosition = this._objectGrabbed.transform.position;
        this.originalRotation = this._objectGrabbed.transform.rotation;

        this.StopCoroutine("ReturnObjectBackPosition");
        this.StopCoroutine("ReturnObjectBackRotation");

        this.StartCoroutine("BringObjectForwardPosition");
        this.StartCoroutine("BringObjectForwardRotation");
    }

    public void ObjectDropped(GameObject objectDropped)
    {
        this.StopCoroutine("BringObjectForwardPosition");
        this.StopCoroutine("BringObjectForwardRotation");

        this.StartCoroutine("ReturnObjectBackPosition");
        this.StartCoroutine("ReturnObjectBackRotation");
    }

    IEnumerator BringObjectForwardPosition()
    {
        while (this._objectGrabbed.transform.position != this.finalPosition.position)
        {
            this._objectGrabbed.transform.position = Vector3.MoveTowards(this._objectGrabbed.transform.position, this.finalPosition.position, this.speed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator BringObjectForwardRotation()
    {
        while (this._objectGrabbed.transform.rotation != this.finalPosition.rotation)
        {
            this._objectGrabbed.transform.rotation = Quaternion.RotateTowards(this._objectGrabbed.transform.rotation, this.finalPosition.rotation, this.rotSpeed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator ReturnObjectBackPosition()
    {
        while (this._objectGrabbed.transform.position != this.originalPosition)
        {
            this._objectGrabbed.transform.position = Vector3.MoveTowards(this._objectGrabbed.transform.position, this.originalPosition, this.speed * Time.deltaTime);

            yield return null;
        }
    }

    IEnumerator ReturnObjectBackRotation()
    {
        while (this._objectGrabbed.transform.rotation != this.originalRotation)
        {
            this._objectGrabbed.transform.rotation = Quaternion.RotateTowards(this._objectGrabbed.transform.rotation, this.originalRotation, this.rotSpeed * Time.deltaTime);

            yield return null;
        }
    }
}