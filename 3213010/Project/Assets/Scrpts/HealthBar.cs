using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//NOTICE: We are including this library!
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    //Referencing the slider image, indicating HP level to player

    public void SetMaxHealth(int health)
    //public function for setting the max HP
    {
        slider.maxValue = health;
        slider.value = health;
        //We set the slider to max HP by default here
    }

    public void SetHealth(int health)
    //public function for changing the current Player's HP
    {
        slider.value = health;
    }
}
