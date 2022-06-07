using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ExtendedButton))]
public class InterfaceSlot : MonoBehaviour
{
    [SerializeField] Image itemIMG;
    [SerializeField] Text amountTXT;
    ExtendedButton exBTN;
    private void Awake()
    {
        exBTN = GetComponent<ExtendedButton>();
    }
    public void Setup(Sprite _itemIMG, int _amount)
    {
        itemIMG.sprite = _itemIMG;
        itemIMG.enabled = _itemIMG != null ? true : false;
        amountTXT.text = _amount > 1 ? _amount.ToString("n0") : null;
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
        if (!exBTN) { if (!FindExtButton()) { return; } }
        exBTN.PointerEnterAction = _OnEnter;
        exBTN.PointerExitAction = _OnExit;
    }
    public void SetPressActions(Action _OnPress, Action _OnPressDown, Action _OnPressUp, PointerBTNTypes targetButton)
    {
        if (!exBTN) { if (!FindExtButton()) { return; } }
        switch (targetButton)
        {
            case PointerBTNTypes.Any:
                exBTN.PointerAnyBTNAction = _OnPress;
                exBTN.PointerAnyBTNDownAction = _OnPressDown;
                exBTN.PointerAnyBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Left:
                exBTN.PointerLeftBTNAction = _OnPress;
                exBTN.PointerLeftBTNDownAction = _OnPressDown;
                exBTN.PointerLeftBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Middle:
                exBTN.PointerMiddleBTNAction = _OnPress;
                exBTN.PointerMiddleBTNDownAction = _OnPressDown;
                exBTN.PointerMiddleBTNUpAction = _OnPressUp;
                break;
            case PointerBTNTypes.Right:
                exBTN.PointerRightBTNAction = _OnPress;
                exBTN.PointerRightBTNDownAction = _OnPressDown;
                exBTN.PointerRightBTNUpAction = _OnPressUp;
                break;
            default:
                break;
        }
    }
    public void SetDragActions(Action _OnDrag, Action _OnDragStart, Action _OnDragEnd, PointerBTNTypes targetButton)
    {
        if (!exBTN) { if (!FindExtButton()) { return; } }
        switch (targetButton)
        {
            case PointerBTNTypes.Any:
                exBTN.PointerAnyBTNDragAction = _OnDrag;
                exBTN.PointerAnyBTNDragStartAction = _OnDragStart;
                exBTN.PointerAnyBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Left:
                exBTN.PointerLeftBTNDragAction = _OnDrag;
                exBTN.PointerLeftBTNDragStartAction = _OnDragStart;
                exBTN.PointerLeftBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Middle:
                exBTN.PointerMiddleBTNDragAction = _OnDrag;
                exBTN.PointerMiddleBTNDragStartAction = _OnDragStart;
                exBTN.PointerMiddleBTNDragEndAction = _OnDragEnd;
                break;
            case PointerBTNTypes.Right:
                exBTN.PointerRightBTNDragAction = _OnDrag;
                exBTN.PointerRightBTNDragStartAction = _OnDragStart;
                exBTN.PointerRightBTNDragEndAction = _OnDragEnd;
                break;
            default:
                break;
        }
    }
    public bool FindExtButton()
    {
        if (exBTN == null) exBTN = GetComponent<ExtendedButton>();
        if (exBTN == null) { Debug.Log("Extended Button Component Missing! Cannot apply actions!"); return false; }
        else { return true; }
    }
}
