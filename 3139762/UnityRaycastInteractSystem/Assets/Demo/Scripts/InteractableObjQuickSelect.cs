using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObjQuickSelect : MonoBehaviour, IInteractable, IInteractableInfo
{
    [SerializeField] ChangeColour cube;
    [SerializeField] SelectWheelCtrl swCtrl;
    [SerializeField] InteractableInfo info;
    [SerializeField] Color[] colourOptions;
    [SerializeField] bool interactActive = true;

    List<WheelItem> quickSelectOptions = new List<WheelItem>();
    private void Start()
    {
        for (int i = 0; i < colourOptions.Length; i++)
        {
            Color colour = colourOptions[i];
            quickSelectOptions.Add(new WheelItem("CHANGE COLOUR", "Change cube to colour", null, colour, () => { cube.SetColour(colour); }));
        }
    }
    public void OnMainInteract(GameObject _sender)
    {
        cube.SetColour(new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), 1));
    }
    public void OnAltInteract(GameObject _sender)
    {
        swCtrl.OpenSelectWheel(quickSelectOptions);
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
