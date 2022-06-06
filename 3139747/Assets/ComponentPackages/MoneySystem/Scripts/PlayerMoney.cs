using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public int money;
    public Text moneyText;
    // Start is called before the first frame update
    void Start()
    {
        money = 0;
        moneyText.text = money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addMoney(int moneytoAdd)
    {
        money += moneytoAdd;
        moneyText.text = money.ToString();
    }

    public void subtractMoney(int moneytoSubtract)
    {
        if (money - moneytoSubtract < 0)
        {
            Debug.Log("We don't have enough money");
        }
        else
        {
            money -= moneytoSubtract;
            moneyText.text = money.ToString();
        }
    }


}
