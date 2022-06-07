using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineCode : Interactable
{
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0f;
    }

    public override void OnFocus()
    {
        outline.OutlineWidth = 10f;
    }
        
    public override void OnLoseFocus()
    {
        outline.OutlineWidth = 0f;
    }
    
    public override void OnInteract()
    {

    }
}
