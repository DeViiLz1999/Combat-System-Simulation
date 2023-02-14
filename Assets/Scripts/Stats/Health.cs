using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(int maxhealth)
    {
        healthSlider.maxValue = maxhealth; // slider max values == player.maxhealth
        healthSlider.value = maxhealth;
    }

    public void SetCurrentHealth(int currenthealth)
    {
        healthSlider.value = currenthealth;
    }
}
