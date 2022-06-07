using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class FPPlayerInput : MonoBehaviour
{
	[Header("Player Input Settings")]
	[SerializeField] PlayerInput pInput;
	[SerializeField]
	string
		moveActionName = "Move",
		lookActionName = "Look",
		jumpActionName = "Jump",
		sprintActionName = "Sprint",
		interactActionName = "Interact";

	[Header("Mouse Cursor Settings")]
	public bool cursorLocked = true;
	public bool cursorInputForLook = true;

	public UnityEvent onInteract, onAltInteract;

	public Vector2 moveDir { get; private set; }
	public Vector2 lookDir { get; private set; }
	public bool jumpPressed { get; private set; }
	public bool sprintPressed { get; private set; }
	public bool interactPressed { get; private set; }
	public bool altInteractPressed { get; private set; }

	InputAction 
		moveAction,
		lookAction,
		jumpAction,
		sprintAction,
		interactAction;

    private void OnEnable()
    {
        if (SetupPlayerInput())
        {
			moveAction = pInput.actions[moveActionName];
			lookAction = pInput.actions[lookActionName];
			jumpAction = pInput.actions[jumpActionName];
			sprintAction = pInput.actions[sprintActionName];
			interactAction = pInput.actions[interactActionName];

			moveAction.performed += OnMove;
			moveAction.canceled += OnMove;
			lookAction.performed += OnLook;
			lookAction.canceled += OnLook;
			jumpAction.performed += OnJump;
			jumpAction.canceled += OnJump;
			sprintAction.performed += OnSprint;
			sprintAction.canceled += OnSprint;
			interactAction.performed += OnInteract;
			interactAction.canceled += OnInteract;
		}
	}
    private void OnDisable()
    {
		if (SetupPlayerInput())
		{
			moveAction.performed -= OnMove;
			moveAction.canceled -= OnMove;
			lookAction.performed -= OnLook;
			lookAction.canceled -= OnLook;
			jumpAction.performed -= OnJump;
			jumpAction.canceled -= OnJump;
			sprintAction.performed -= OnSprint;
			sprintAction.canceled -= OnSprint;
			interactAction.performed -= OnInteract;
			interactAction.canceled -= OnInteract;
		}
	}
    public bool SetupPlayerInput()
    {
		if(pInput != null) { return true; }
		if (TryGetComponent(out PlayerInput _pInput))
		{
			pInput = _pInput;
			return true;
		}
		else
		{
			Debug.LogError("No PlayerInput component found on self! Disabling FPPlayerInput!", transform);
			this.enabled = false;
			return false;
		}
	}
	//Input
    public void OnMove(InputAction.CallbackContext ctx)
	{
		MoveInput(ctx.performed ? ctx.ReadValue<Vector2>() : Vector2.zero);
	}

	public void OnLook(InputAction.CallbackContext ctx)
	{
		LookInput(ctx.performed && cursorInputForLook ? ctx.ReadValue<Vector2>() : Vector2.zero);
	}

	public void OnJump(InputAction.CallbackContext ctx)
	{
		JumpInput(ctx.performed ? true : false);
	}

	public void OnSprint(InputAction.CallbackContext ctx)
	{
		SprintInput(ctx.performed ? true : false);
	}

	public void OnInteract(InputAction.CallbackContext ctx)
	{
		if(ctx.interaction is TapInteraction)
        {
			InteractInput(ctx.performed ? true : false);
		}
		if (ctx.interaction is HoldInteraction)
		{
			AltInteractInput(ctx.performed ? true : false);
		}
	}

	//Set Values
	public void MoveInput(Vector2 newMoveDirection)
	{
		moveDir = newMoveDirection;
	}

	public void LookInput(Vector2 newLookDirection)
	{
		lookDir = newLookDirection;
	}

	public void JumpInput(bool _pressed)
	{
		jumpPressed = _pressed;
	}

	public void SprintInput(bool _pressed)
	{
		sprintPressed = _pressed;
	}

	public void InteractInput(bool _pressed)
	{
		interactPressed = _pressed;
		if(_pressed) { onInteract?.Invoke(); }
	}
	public void AltInteractInput(bool _pressed)
	{
		altInteractPressed = _pressed;
		if (_pressed) { onAltInteract?.Invoke(); }
	}

	private void OnApplicationFocus(bool hasFocus)
	{
		SetCursorState(cursorLocked);
	}

	private void SetCursorState(bool newState)
	{
		Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
	}
}
