using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using static UnityEvents;

public class GrabScript : MonoBehaviour
{
    public Transform origin;
    public float raycastDistance;
    public float RotationSpeed = 10;

    [SerializeField] ObjectGrabbedEvent onObjectGrabbed;
    [SerializeField] ObjectDroppedEvent onObjectDropped;

    public KeyCode grabObject;
    public LayerMask grabableObjectLayer;

    GameObject _objectGrabbed;
    Quaternion originRotation;

    public Behaviour movement;

    void Update()
    {
        if (Input.GetKeyDown(this.grabObject))
        {
            RaycastHit hit;

            if (Physics.Raycast(this.Origin.position, this.Origin.forward, out hit, this.raycastDistance, this.grabableObjectLayer))
            {
                originRotation = hit.collider.gameObject.transform.rotation;

                this._objectGrabbed = hit.collider.gameObject;

                this.onObjectGrabbed.Invoke(this._objectGrabbed);
                movement.enabled = !movement.enabled;
            }

        }

        if (Input.GetKeyUp(this.grabObject))
        {

            if (this._objectGrabbed != null)
            {
                this.onObjectDropped.Invoke(this._objectGrabbed);

                movement.enabled = !movement.enabled;

                _objectGrabbed.transform.rotation = originRotation;
                this._objectGrabbed = null;

            }
        }
    }

    protected Transform Origin
    {
        get
        {
            if (this.origin == null)
            {
                return Camera.main.transform;

            }
            else
            {
                return this.origin;
            }
        }
    }

    public ObjectGrabbedEvent ObjectGrabbedEvent
    {
        get
        {
            return this.onObjectGrabbed;
        }
        set
        {
            this.onObjectGrabbed = value;
        }
    }

    public ObjectDroppedEvent ObjectDroppedEvent
    {
        get
        {
            return this.onObjectDropped;
        }
        set
        {
            this.onObjectDropped = value;
        }
    }
}