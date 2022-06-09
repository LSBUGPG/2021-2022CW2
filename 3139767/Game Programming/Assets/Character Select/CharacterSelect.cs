using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    [SerializeField]
    public GameObject[] skins;
    [SerializeField]
    public int selectedCharacter;
    public Character[] characters;

    public Button unlockBTN;
    public Text coinsTXT;
    private void Awake()
    {
        selectedCharacter = PlayerPrefs.GetInt("SelectCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);
        skins[selectedCharacter].SetActive(true);
        foreach (Character c in characters)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();

    }
    public void ChangeNext()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;
        skins[selectedCharacter].SetActive(true);
        if(characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectCharacter", selectedCharacter);
        UpdateUI();

    }
    public void ChangePrevious()
    {
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;
        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectCharacter", selectedCharacter);
        UpdateUI();
    }
    public void UpdateUI()
    {
        coinsTXT.text = "Coins: " + PlayerPrefs.GetInt("score", 0);
        if (characters[selectedCharacter].isUnlocked == true)
            unlockBTN.gameObject.SetActive(false);
        else
        {
            unlockBTN.GetComponentInChildren<Text>().text = "Price: " + characters[selectedCharacter].price;
            if (PlayerPrefs.GetInt("score", 0) < characters[selectedCharacter].price)
            {
                unlockBTN.gameObject.SetActive(true);
                unlockBTN.interactable = false;
            }
            else
            {
                unlockBTN.gameObject.SetActive(true);
                unlockBTN.interactable = true;
            }

        }
    }
    public void Unlock()
    {
        int coins = PlayerPrefs.GetInt("score", 0);
        int price = characters[selectedCharacter].price;
        PlayerPrefs.SetInt("score", coins - price);
        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }
}