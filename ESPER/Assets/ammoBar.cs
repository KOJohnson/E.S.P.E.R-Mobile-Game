using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoBar : MonoBehaviour
{
    // Slider variable
    public Slider slider;
    // Function to set slider value to health value
    public void setAmmo(int ammo)
    {

        slider.value = ammo;
    }

    public void setMaxAmmo(int ammo)
    {

        slider.maxValue = ammo;
        slider.value = ammo;
    }
}
