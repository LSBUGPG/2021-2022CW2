using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    [SerializeField] PlayerRCInteract player;
    [SerializeField] Image bg;
    [SerializeField] Text actionTXT, descTXT;
    [SerializeField] Color lockedColour = Color.red, unlockedColour = Color.green;

    Color bgColour;
    private void Start()
    {
        bgColour = bg.color;
    }
    void OnEnable()
    {
        player.OnInteractChange += UpdateUI; 
    }

    private void OnDisable()
    {
        player.OnInteractChange -= UpdateUI;
    }
    void UpdateUI()
    {
        InteractableInfo data;
        if (player.TargetInteractable != null)
        {
            IInteractableInfo info = (IInteractableInfo)player.TargetInteractable;
            if(info != null)
            {
                data = info.GetInteractableInfo(player.gameObject);
                
            }
            else
            {
                data = null;
            }
        }
        else { data = null; }

        
        /*if (data != null)
        {
            actionTXT.text = data.action;
            actionTXT.color = data.actionColor.a <= 0 ? (data.locked ? lockedColour : unlockedColour) : data.actionColor;
            actionTXT.enabled = data.enabled;
            descTXT.text = data.description;
            descTXT.color = data.descriptionColor.a <= 0 ? (data.locked ? lockedColour : unlockedColour) : data.descriptionColor;
            descTXT.enabled = data.enabled;
        }*/
        actionTXT.text = data != null ? (data.enabled ? data.action : null) : null;
        actionTXT.color = data != null ? (data.actionColor.a <= 0 ? (data.locked ? lockedColour : unlockedColour) : data.actionColor) : actionTXT.color;
        descTXT.text = data != null ? (data.enabled ? data.description : null) : null;
        descTXT.color = data != null ? (data.descriptionColor.a <= 0 ? (data.locked ? lockedColour : unlockedColour) : data.descriptionColor) : descTXT.color;
        bg.color = actionTXT.text != "" || descTXT.text != "" ? bgColour : new Color(0, 0, 0, 0); ;
    }
}
