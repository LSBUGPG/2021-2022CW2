using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReduceMoney : MonoBehaviour
{
    public GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Camera.GetComponent<PlayerMoney>().addMoney(5);
        }
        if (Input.GetButtonDown ("Fire2"))
        {
            Camera.GetComponent<PlayerMoney>().subtractMoney(5);
        }
    }
}
