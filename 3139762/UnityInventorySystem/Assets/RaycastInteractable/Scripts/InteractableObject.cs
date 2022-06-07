using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableObject : MonoBehaviour
{
    public Action mainInteract;
    public Action secondaryInteract;
    public InteractableInfo interactInfo;
}
[System.Serializable]
public class InteractableInfo
{
    public string interactAction;
    public string interactDescription;
    public Sprite interactableIMG;
}
