using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExtendedButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    //Pointer
    public Action PointerEnterAction = null;
    public Action PointerExitAction = null;

    //Any Mouse BTN
    public Action PointerAnyBTNAction = null;
    public Action PointerAnyBTNDownAction = null;
    public Action PointerAnyBTNUpAction = null;

    public Action PointerAnyBTNDragAction = null;
    public Action PointerAnyBTNDragStartAction = null;
    public Action PointerAnyBTNDragEndAction = null;

    //Left Mouse BTN
    public Action PointerLeftBTNAction = null;
    public Action PointerLeftBTNDownAction = null;
    public Action PointerLeftBTNUpAction = null;

    public Action PointerLeftBTNDragAction = null;
    public Action PointerLeftBTNDragStartAction = null;
    public Action PointerLeftBTNDragEndAction = null;

    //Middle Mouse BTN
    public Action PointerMiddleBTNAction = null;
    public Action PointerMiddleBTNDownAction = null;
    public Action PointerMiddleBTNUpAction = null;

    public Action PointerMiddleBTNDragAction = null;
    public Action PointerMiddleBTNDragStartAction = null;
    public Action PointerMiddleBTNDragEndAction = null;

    //Right Mouse BTN
    public Action PointerRightBTNAction = null;
    public Action PointerRightBTNDownAction = null;
    public Action PointerRightBTNUpAction = null;

    public Action PointerRightBTNDragAction = null;
    public Action PointerRightBTNDragStartAction = null;
    public Action PointerRightBTNDragEndAction = null;

    public bool buttonEnabled = true;
    bool isMouseOver;
    //Hover Behaviour
    public enum HoverModes
    {
        Off,
        ChangeColour,
        ChangeImage,
        Animator
    }
    public HoverModes hoverMode = HoverModes.Off;
    public Image targetImage;

    [Header("Hover Colours")]
    public Color normalColour = Color.white;
    public Color hoverColour = new Color(.9f, .9f, .9f, 1);
    public Color disabledColour = new Color(.5f, .5f, .5f, 1);
    public bool useLeftPressColourForAllPresses = true;
    public Color leftPressColour = new Color(.8f, .8f, .8f, 1);
    public Color middlePressColour = new Color(.8f, .8f, .8f, 1);
    public Color rightPressColour = new Color(.8f, .8f, .8f, 1);

    [Header("Hover Sprites")]
    public Sprite hoverSprite;
    Sprite defaultSprite;
    public Sprite exitSprite;
    public bool useExitSprite = false;

    [Header("Hover Animator")]
    public Animator buttonAnimator;
    [Tooltip("Leave blank if unused")] public string normalAnimBool = "Normal",
        hoverAnimTrigger = "Hover",
        exitAnimTrigger = "Exit",
        disabledAnimBool = "Disabled",
        anyPressAnimTrigger = "AnyPress",
        leftPressAnimTrigger = "LeftPress",
        middlePressAnimTrigger = "MiddlePress",
        rightPressAnimTrigger = "RightPress",
        releaseAnimTrigger = "Release";
    int normalAnimBoolID, hoverAnimTriggerID, exitAnimTriggerID, disabledAnimBoolID, anyPressAnimTriggerID, leftPressAnimTriggerID, middlePressAnimTriggerID, rightPressAnimTriggerID, releaseAnimTriggerID;

    Action hoverModeEnter, hoverModeExit, hoverModeLeftPress, hoverModeMiddlePress, hoverModeRightPress, hoverModeAnyPress, hoverModeRelease;

    private void Awake()
    {
        if (targetImage != null) { defaultSprite = targetImage.sprite; }

        if (normalAnimBool != null || normalAnimBool != "") { normalAnimBoolID = Animator.StringToHash(normalAnimBool); }
        if (hoverAnimTrigger != null || hoverAnimTrigger != "") { hoverAnimTriggerID = Animator.StringToHash(hoverAnimTrigger); }
        if (exitAnimTrigger != null || exitAnimTrigger != "") { exitAnimTriggerID = Animator.StringToHash(exitAnimTrigger); }
        if (disabledAnimBool != null || disabledAnimBool != "") { disabledAnimBoolID = Animator.StringToHash(disabledAnimBool); }
        if (anyPressAnimTrigger != null || anyPressAnimTrigger != "") { anyPressAnimTriggerID = Animator.StringToHash(anyPressAnimTrigger); }
        if (leftPressAnimTrigger != null || leftPressAnimTrigger != "") { leftPressAnimTriggerID = Animator.StringToHash(leftPressAnimTrigger); }
        if (middlePressAnimTrigger != null || middlePressAnimTrigger != "") { middlePressAnimTriggerID = Animator.StringToHash(middlePressAnimTrigger); }
        if (rightPressAnimTrigger != null || rightPressAnimTrigger != "") { rightPressAnimTriggerID = Animator.StringToHash(rightPressAnimTrigger); }
        if (releaseAnimTrigger != null || releaseAnimTrigger != "") { releaseAnimTriggerID = Animator.StringToHash(releaseAnimTrigger); }
    }
    private void Update()
    {
        if(hoverMode == HoverModes.Animator)
        {
            if(buttonAnimator != null) {
                if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, isMouseOver ? false : true); } if (disabledAnimBool != null || disabledAnimBool != "") { buttonAnimator.SetBool(disabledAnimBoolID, buttonEnabled ? false : true); } }
        }
    }
    public enum PointerBTNTypes
    {
        Any,
        Left,
        Middle,
        Right
    }
    public void SetPointerActions(Action _OnEnter, Action _OnExit)
    {
        PointerEnterAction = _OnEnter;
        PointerExitAction = _OnExit;
    }
    public void SetPressActions(Action _OnPress, Action _OnPressDown, Action _OnPressUp, PointerBTNTypes targetButton)
    {
        switch (targetButton)
        {
            case PointerBTNTypes.Any:
                PointerAnyBTNAction = _OnPress;
                PointerAnyBTNDownAction = _OnPressDown;
                PointerAnyBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Left:
                PointerLeftBTNAction = _OnPress;
                PointerLeftBTNDownAction = _OnPressDown;
                PointerLeftBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Middle:
                PointerMiddleBTNAction = _OnPress;
                PointerMiddleBTNDownAction = _OnPressDown;
                PointerMiddleBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Right:
                PointerRightBTNAction = _OnPress;
                PointerRightBTNDownAction = _OnPressDown;
                PointerRightBTNUpAction = _OnPressUp;
                break;
            default:
                break;
        }
    }
    public void SetDragActions(Action _OnDrag, Action _OnDragStart, Action _OnDragEnd, PointerBTNTypes targetButton)
    {
        switch (targetButton)
        {
            case PointerBTNTypes.Any:
                PointerAnyBTNDragAction = _OnDrag;
                PointerAnyBTNDragStartAction = _OnDragStart;
                PointerAnyBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Left:
                PointerLeftBTNDragAction = _OnDrag;
                PointerLeftBTNDragStartAction = _OnDragStart;
                PointerLeftBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Middle:
                PointerMiddleBTNDragAction = _OnDrag;
                PointerMiddleBTNDragStartAction = _OnDragStart;
                PointerMiddleBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Right:
                PointerRightBTNDragAction = _OnDrag;
                PointerRightBTNDragStartAction = _OnDragStart;
                PointerRightBTNDragEndAction = _OnDragEnd;
                break;
            default:
                break;
        }
    }
    //Pointer
    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        PointerEnterAction?.Invoke();
        hoverModeEnter?.Invoke();
        isMouseOver = true;
    }
    public virtual void OnPointerExit(PointerEventData eventData)
    {
        PointerExitAction?.Invoke();
        hoverModeExit?.Invoke();
        isMouseOver = false;
    }

    //Click
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        PointerAnyBTNAction?.Invoke();
        hoverModeAnyPress?.Invoke();
        if(eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNAction?.Invoke(); hoverModeLeftPress?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNAction?.Invoke(); hoverModeMiddlePress?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerMiddleBTNAction?.Invoke(); hoverModeRightPress?.Invoke(); }
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        PointerAnyBTNDownAction?.Invoke();
        if (eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNDownAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNDownAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerRightBTNDownAction?.Invoke(); }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        PointerAnyBTNUpAction?.Invoke();
        hoverModeRelease?.Invoke();
        if (eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNUpAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNUpAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerRightBTNUpAction?.Invoke(); }
    }

    //Drag
    public virtual void OnDrag(PointerEventData eventData)
    {
        PointerAnyBTNDragAction?.Invoke();
        if (eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNDragAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNDragAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerRightBTNDragAction?.Invoke(); }
    }

    public virtual void OnBeginDrag(PointerEventData eventData)
    {
        PointerAnyBTNDragStartAction?.Invoke();
        if (eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNDragStartAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNDragStartAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerRightBTNDragStartAction?.Invoke(); }
    }

    public virtual void OnEndDrag(PointerEventData eventData)
    {
        PointerAnyBTNDragEndAction?.Invoke();
        if (eventData.button == PointerEventData.InputButton.Left) { PointerLeftBTNDragEndAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Middle) { PointerMiddleBTNDragEndAction?.Invoke(); }
        if (eventData.button == PointerEventData.InputButton.Right) { PointerRightBTNDragEndAction?.Invoke(); }
    }
    public bool IsMouseOver()
    {
        return isMouseOver;
    }
    public void SetHoverMode(HoverModes mode)
    {
        this.hoverMode = mode;
        switch (hoverMode)
        {
            case HoverModes.Off:
                hoverModeEnter = null;
                hoverModeExit = null;
                hoverModeAnyPress = null;
                hoverModeLeftPress = null;
                hoverModeMiddlePress = null;
                hoverModeRightPress = null;
                hoverModeRelease = null;
                break;
            case HoverModes.ChangeColour:
                if(targetImage != null)
                {
                    hoverModeEnter = delegate () { targetImage.color = hoverColour; };
                    hoverModeExit = delegate () { targetImage.color = normalColour; };
                    if (useLeftPressColourForAllPresses) hoverModeAnyPress = delegate () { targetImage.color = leftPressColour; };
                    if (!useLeftPressColourForAllPresses) hoverModeLeftPress = delegate () { targetImage.color = leftPressColour; };
                    if (!useLeftPressColourForAllPresses) hoverModeMiddlePress = delegate () { targetImage.color = middlePressColour; };
                    if (!useLeftPressColourForAllPresses) hoverModeRightPress = delegate () { targetImage.color = rightPressColour; };
                    hoverModeRelease = delegate () { targetImage.color = normalColour; };
                }
                else { Debug.Log("No Target Image referenced!"); }
                break;
            case HoverModes.ChangeImage:
                if(targetImage != null)
                {
                    hoverModeEnter = delegate () { targetImage.sprite = hoverSprite; };
                    if(useExitSprite) hoverModeExit = delegate () { targetImage.sprite = exitSprite; };
                    hoverModeAnyPress = null;
                    hoverModeLeftPress = null;
                    hoverModeMiddlePress = null;
                    hoverModeRightPress = null;
                    hoverModeRelease = null;
                }
                else { Debug.Log("No Target Image referenced!"); }
                
                break;
            case HoverModes.Animator:
                if(buttonAnimator != null)
                {
                    hoverModeEnter = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (hoverAnimTrigger != null || hoverAnimTrigger != "") { buttonAnimator.SetTrigger(hoverAnimTriggerID); } };
                    hoverModeExit = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, true); }
                        if (exitAnimTrigger != null || exitAnimTrigger != "") { buttonAnimator.SetTrigger(exitAnimTriggerID); }
                    };
                    hoverModeAnyPress = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (anyPressAnimTrigger != null || anyPressAnimTrigger != "") { buttonAnimator.SetTrigger(anyPressAnimTriggerID); }
                    };
                    hoverModeLeftPress = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (leftPressAnimTrigger != null || leftPressAnimTrigger != "") { buttonAnimator.SetTrigger(leftPressAnimTriggerID); }
                    };
                    hoverModeMiddlePress = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (middlePressAnimTrigger != null || middlePressAnimTrigger != "") { buttonAnimator.SetTrigger(middlePressAnimTriggerID); } };
                    hoverModeRightPress = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (rightPressAnimTrigger != null || rightPressAnimTrigger != "") { buttonAnimator.SetTrigger(rightPressAnimTriggerID); } };
                    hoverModeRelease = delegate () { if (normalAnimBool != null || normalAnimBool != "") { buttonAnimator.SetBool(normalAnimBoolID, false); }
                        if (releaseAnimTrigger != null || releaseAnimTrigger != "") { buttonAnimator.SetTrigger(releaseAnimTriggerID); } };
                }else { Debug.Log("No Button animator referenced!"); }
                break;
        }
    }
    public void RefreshHoverMode()
    {
        SetHoverMode(hoverMode);
    }
}
