using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    // Slider variable
    public Slider healthSlider;
    // Function to set slider value to health value
    public void setHealth(int health) {

        healthSlider.value = health;
    }

    public void setMaxHealth(int health) {

        healthSlider.maxValue = health;
        healthSlider.value = health;
    }
}
