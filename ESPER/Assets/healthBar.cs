using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Slider variable
    public Slider slider;
    // Function to set slider value to health value
    public void setHealth(int health) {

        slider.value = health;
    }

    public void setMaxHealth(int health) {

        slider.maxValue = health;
        slider.value = health;
    }
}
