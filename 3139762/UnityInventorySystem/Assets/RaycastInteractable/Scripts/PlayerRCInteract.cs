using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRCInteract : MonoBehaviour
{
    [SerializeField] float interactRange = 3f;
    [SerializeField] float interactHitRadius = .2f;
    [SerializeField] LayerMask raycastCollideLayers;
    [SerializeField] LayerMask interactableLayers;

    [SerializeField] InputAction interactInput;
    public bool useSelfInput { get; set; } = true ;

    [SerializeField] Transform testSphere;

    Collider[] foundInteractables;
    public InteractableObject currInteractable { get; private set; }
    private void OnEnable()
    {
        if (useSelfInput)
        {
            interactInput.Enable();
            interactInput.performed += context => { if (context.performed) Interact(); };
        }
    }
    private void OnDisable()
    {
        if (useSelfInput)
        {
            interactInput.Disable();
        }
    }
    private void Update()
    {
        FindInteractable();
    }
    void Interact()
    {
        if (currInteractable == null) { Debug.Log("Current Interact is null"); return; }
        Debug.Log("Interacting with current interact");
        currInteractable.mainInteract?.Invoke();
    }
    void FindInteractable()
    {
        if (testSphere != null) { testSphere.position = GetAimPos(); }

        foundInteractables = Physics.OverlapSphere(GetAimPos(), interactHitRadius, interactableLayers, QueryTriggerInteraction.Collide);

        if(foundInteractables.Length > 0)
        {
            if (foundInteractables[0] != null)
            {
                currInteractable = foundInteractables[0].GetComponent<InteractableObject>();
            }
            else { currInteractable = null; }
        }
        else { currInteractable = null; }
    }
    Vector3 GetAimPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        if (Physics.Raycast(ray, out RaycastHit rcHit, interactRange, raycastCollideLayers, QueryTriggerInteraction.Collide))
        {
            return rcHit.point;
        }
        return ray.GetPoint(interactRange);
    }
}
