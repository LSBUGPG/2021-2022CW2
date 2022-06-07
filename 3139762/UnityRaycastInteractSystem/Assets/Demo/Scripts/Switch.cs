using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] Animator anim;
    public UnityEvent SwitchOnEvent, SwitchOffEvent;
    [SerializeField] bool switchActive = false;
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
}
