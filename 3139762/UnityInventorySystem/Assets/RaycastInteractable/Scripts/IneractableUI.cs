using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IneractableUI : MonoBehaviour
{
    [SerializeField] Text actionTXT;
    [SerializeField] Text descTXT;
    [SerializeField] PlayerRCInteract pInteract;

    InteractableObject _currObj;
    InteractableObject CurrObj { get { return _currObj; } set { _currObj = value; UpdateUI(); } }

    private void Update()
    {
        CurrObj = pInteract.currInteractable;
    }

    void UpdateUI()
    {
        actionTXT.text = CurrObj != null ? CurrObj.interactInfo.interactAction : null;
        descTXT.text = CurrObj != null ? CurrObj.interactInfo.interactDescription : null;
    }
}
