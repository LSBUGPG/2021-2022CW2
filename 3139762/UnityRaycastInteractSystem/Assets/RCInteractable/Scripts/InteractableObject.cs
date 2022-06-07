using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour, IInteractable, IInteractableInfo
{
    [SerializeField] InteractableInfo info;
    [SerializeField] UnityEvent<GameObject> mainInteractEvent, altInteractEvent;
    public Action<GameObject> mainInteractAction, altInteractAction;
    [SerializeField] bool interactActive = true;
    public void OnMainInteract(GameObject _sender)
    {
        mainInteractEvent?.Invoke(_sender);
        mainInteractAction?.Invoke(_sender);
    }
    public void OnAltInteract(GameObject _sender)
    {
        altInteractEvent?.Invoke(_sender);
        altInteractAction?.Invoke(_sender);
    }
    public bool GetInteractActive(GameObject _sender)
    {
        return interactActive;
    }
    public void SetInteractActive(bool _active, GameObject _sender)
    {
        interactActive = _active;
    }
    public InteractableInfo GetInteractableInfo(GameObject _sender)
    {
        return info;
    }
}
