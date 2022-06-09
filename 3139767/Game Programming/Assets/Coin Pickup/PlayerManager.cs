using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject[] playerPrefabs;
    int characterIndex;
    // Start is called before the first frame update
    void Awake()
    {
        characterIndex =  PlayerPrefs.GetInt("SelectCharacter", 0);
        Instantiate(playerPrefabs[characterIndex], transform.position, Quaternion.identity);
        playerPrefabs[characterIndex].SetActive(true);
    }

}
