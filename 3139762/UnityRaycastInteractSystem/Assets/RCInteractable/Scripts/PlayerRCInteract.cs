using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRCInteract : MonoBehaviour
{
    [Tooltip("Max range of interact SphereCast")][SerializeField] float interactRange = 3f;
    [Tooltip("Radius of interact SphereCast")][SerializeField] float interactHitRadius = .2f;
    [Tooltip("Layers that the interact SphereCast will detect and collide with")][SerializeField] LayerMask interactHitLayers;

    public Action OnInteractChange;
    public IInteractable TargetInteractable { get { return targetInteractable; } set { targetInteractable = value; OnInteractChange?.Invoke(); } }
    IInteractable targetInteractable;
    Vector3 interactRCEndPos;
    bool manualOverride = false;
    private void Update()
    {
        RCIneractCtrl();
    }
    public void InteractMain()
    {
        if(targetInteractable != null)
        {
            targetInteractable.OnMainInteract(gameObject);
        }
    }
    public void InteractAlt()
    {
        if (targetInteractable != null)
        {
            targetInteractable.OnAltInteract(gameObject);
        }
    }
    public void ManualSet(IInteractable _interact, bool _enabled)
    {
        if (_enabled)
        {
            manualOverride = _enabled;
            TargetInteractable = _interact;
        }
        else
        {
            manualOverride = false;
        }
    }
    void RCIneractCtrl()
    {
        if (!manualOverride)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.SphereCast(ray, interactHitRadius, out RaycastHit hit, interactRange, interactHitLayers))
            {
                if (hit.transform.TryGetComponent(out IInteractable interactable))
                {
                    TargetInteractable = interactable;
                }
                else
                {
                    TargetInteractable = null;
                }
                interactRCEndPos = hit.point;
            }
            else
            {
                TargetInteractable = null;
                interactRCEndPos = ray.GetPoint(interactRange);
            }
        }
    }
}
