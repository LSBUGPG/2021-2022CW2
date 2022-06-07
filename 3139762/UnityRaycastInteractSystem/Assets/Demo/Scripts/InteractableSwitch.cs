using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableSwitch : MonoBehaviour, IInteractable, IInteractableInfo
{
    [SerializeField] Animator anim;
    public UnityEvent SwitchOnEvent, SwitchOffEvent;
    [SerializeField] bool switchActive = false;
    [SerializeField] bool interactActive = true;
    [SerializeField] InteractableInfo switchedOnInfo, switchedOffInfo;
    private void Start()
    {
        anim.SetInteger("SwitchState", switchActive ? 2 : 0);
    }
    public void SwitchON(bool _active)
    {
        switchActive = _active;
        if (switchActive)
        {
            SwitchOnEvent?.Invoke();
        }
        else
        {
            SwitchOffEvent?.Invoke();
        }
        anim.SetInteger("SwitchState", switchActive ? 2 : 0);
    }
    public void ToggleSwitch()
    {
        SwitchON(!switchActive);
    }

    public void OnMainInteract(GameObject _sender)
    {
        ToggleSwitch();

    }
    public void OnAltInteract(GameObject _sender)
    {
        return;
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
        if (switchActive)
        {
            return switchedOnInfo;
        }
        else
        {
            return switchedOffInfo;
        }
    }
}
