using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        // Calculate the health percentage
        float healthPercentage = currentHealth / maxHealth;

        // Update the slider value
        _slider.value = healthPercentage;
    }
}
