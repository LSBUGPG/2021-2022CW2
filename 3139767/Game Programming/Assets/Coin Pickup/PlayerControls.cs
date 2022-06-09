using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public int score;
    public int movementSpeed;
    public Text coinText;
    // Update is called once per frame
    private void Awake()
    {
        coinText.text = "Coins: " + PlayerPrefs.GetInt("score", 0);
        score = PlayerPrefs.GetInt("score", score);
    }
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movementSpeed * h, movementSpeed * v);
        movement *= Time.deltaTime;
        transform.Translate(movement);
        PlayerPrefs.SetInt("score", score);
        coinText.text = "Coins: " + PlayerPrefs.GetInt("score", score);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Coins")
        {
            Destroy(collision.gameObject);
            score++;
            //coinText.text = "Coins: " + PlayerPrefs.GetInt("score", score);
            
        }
    }
}
