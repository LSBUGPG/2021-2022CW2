using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateColor : MonoBehaviour
{
    int RandomNumber;
    private float time = 0.0f;
    public float timeperiod = 2f;
    RawImage RawImage1;
    RawImage RawImage2;
    RawImage RawImage3;
    [SerializeField] private Color ContactColor;
    [SerializeField] private Color ContactColor2;
    [SerializeField] private Color ContactColor3;
    private Color OriginalColor;

    // Start is called before the first frame update
    void Start()
    {
        RawImage1 = GameObject.FindGameObjectWithTag("Circle1").GetComponent<RawImage>();
        RawImage2 = GameObject.FindGameObjectWithTag("Circle2").GetComponent<RawImage>();
        RawImage3 = GameObject.FindGameObjectWithTag("Circle3").GetComponent<RawImage>();
        OriginalColor = RawImage1.color;
        OriginalColor = RawImage2.color;
        OriginalColor = RawImage3.color;
        RandomNumber = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timeperiod)
        {
            time = 0.0f;
            GenerateAColor();
        }
    }

    private void GenerateAColor()
    {
        int RandomNumber = Random.Range(0, 3);
        Debug.Log(RandomNumber);
        if (RandomNumber == 0)
        {
            Debug.Log(RandomNumber);

            RawImage1.color = ContactColor;
        }

        if (RandomNumber == 1)
        {
            Debug.Log(RandomNumber);

            RawImage1.color = ContactColor2;
        }

        if (RandomNumber == 2)
        {
            Debug.Log(RandomNumber);
            RawImage1.color = ContactColor3;
        }

        int RandomNumber2 = Random.Range(0, 3);

        if (RandomNumber2 == 0)
        {
            RawImage2.color = ContactColor;
        }

        if (RandomNumber2 == 1)
        {
            RawImage2.color = ContactColor2;
        }

        if (RandomNumber2 == 2)
        {
            RawImage2.color = ContactColor3;
        }
        int RandomNumber3 = Random.Range(0, 3);

        if (RandomNumber3 == 0)
        {
            RawImage3.color = ContactColor;
        }

        if (RandomNumber3 == 1)
        {
            RawImage3.color = ContactColor2;
        }

        if (RandomNumber3 == 2)
        {
            RawImage3.color = ContactColor3;
        }
    }
}
           

