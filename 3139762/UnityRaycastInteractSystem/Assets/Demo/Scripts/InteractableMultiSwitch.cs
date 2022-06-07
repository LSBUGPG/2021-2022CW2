using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableMultiSwitch : MonoBehaviour, IInteractable, IInteractableInfo
{
    [SerializeField] Animator anim;
    [SerializeField] ChangeColour cube, switchHandle;
    [SerializeField] bool switchActive = false;
    [SerializeField] bool interactActive = true;
    int switchPos = 0;
    private void Start()
    {
        anim.SetInteger("SwitchState", switchActive ? switchPos+1 : 0);
    }
    public void SwitchON(bool _active)
    {
        switchActive = _active;

        anim.SetInteger("SwitchState", switchActive ? switchPos+1 : 0);
        cube.gameObject.SetActive(_active);
        cube.SwitchColour(switchPos);
        switchHandle.SwitchColour(switchActive ? 1 : 0);
    }
    public void ToggleSwitch()
    {
        SwitchON(!switchActive);
    }
    public void ChangeSwitchPosition(int _position)
    {
        if(_position != switchPos)
        {
            switchPos = _position;
            SwitchON(switchActive);
        }
    }

    public void OnMainInteract(GameObject _sender)
    {
        ToggleSwitch();
    }
    public void OnAltInteract(GameObject _sender)
    {
        ChangeSwitchPosition(switchPos == 0 ? 1 : 0);
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
            return new InteractableInfo("SWITCH OFF", Color.red, "Press E to Switch OFF \n Hold E to change the switch's on position", cube.GetColours[switchPos], false, true);
        }
        else
        {
            return new InteractableInfo("SWITCH ON", Color.green, "Press E to Switch OFF \n Hold E to change the switch's on position", cube.GetColours[switchPos], false, true);
        }
    }
}
