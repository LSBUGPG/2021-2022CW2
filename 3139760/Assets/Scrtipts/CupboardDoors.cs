using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardDoors : Interactable
{
    private bool isOpen = false;
    private bool canBeInteractedWith = true;
    private float direction;
    private Animator anim;

    private Outline outline;

    private void Start()
    {
        anim = GetComponent<Animator>();

        outline = GetComponent<Outline>();
        outline.OutlineWidth = 0f;
    }


    public override void OnFocus()
    {
        outline.OutlineWidth = 10f;
    }

    public override void OnInteract()
    {
        if (canBeInteractedWith)
        {
            isOpen = !isOpen;

            if (gameObject.name.StartsWith("Left"))
            {
                direction = -1;
            }

            else
            {
                direction = 1;
            }

            anim.SetFloat("direction", direction);
            anim.SetBool("isOpen", isOpen);

            StartCoroutine(AutoClose());
        }
    }

    public override void OnLoseFocus()
    {
        outline.OutlineWidth = 0f;
    }

    private IEnumerator AutoClose()
    {
        while (isOpen)
        {
            yield return new WaitForSeconds(3);

            if (Vector3.Distance(transform.position, FirstPersonController.instance.transform.position) > 3)
            {
                isOpen = false;
                anim.SetFloat("direction", 0);
                anim.SetBool("isOpen", isOpen);

            }
        }

    }

    private void Animator_LockInteraction()
    {
        canBeInteractedWith = false;
    }

    private void Animator_UnlockInteraction()
    {
        canBeInteractedWith = true;
    }

}
