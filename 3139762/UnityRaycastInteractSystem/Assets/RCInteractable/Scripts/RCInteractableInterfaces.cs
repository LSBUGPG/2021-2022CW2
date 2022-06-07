using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public void OnMainInteract(GameObject _sender);
    public void OnAltInteract(GameObject _sender);
    public bool GetInteractActive(GameObject _sender);
    public void SetInteractActive(bool _active, GameObject _sender);
}
public interface IInteractableInfo
{
    public InteractableInfo GetInteractableInfo(GameObject _sender);
}

[System.Serializable]
public class InteractableInfo
{
    public string action = "USE";
    [TextArea(7, 14)] public string description;
    public Color actionColor = new Color(0, 0, 0, 0), descriptionColor = new Color(0, 0, 0, 0);
    public bool locked = false;
    public bool enabled = true;

    public InteractableInfo()
    {

    }
    public InteractableInfo(string _actionTXT, bool _locked, bool _enabled)
    {
        action = _actionTXT;
        locked = _locked;
        enabled = _enabled;
    }
    public InteractableInfo(string _actionTXT, string _descriptionTXT, bool _locked, bool _enabled)
    {
        action = _actionTXT;
        description = _descriptionTXT;
        locked = _locked;
        enabled = _enabled;
    }
    public InteractableInfo(string _actionTXT, Color _actionColour, string _descriptionTXT, Color _descriptionColour, bool _locked, bool _enabled)
    {
        action = _actionTXT;
        actionColor = _actionColour; 
        description = _descriptionTXT;
        descriptionColor = _descriptionColour;
        locked = _locked;
        enabled = _enabled;
    }
}
