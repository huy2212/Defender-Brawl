using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManaBar : MonoBehaviour
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _slider.value = 0;
    }

    public void UpdateManaBar(float currentMana, float maxMana)
    {
        float manaPercentage = currentMana / maxMana;
        _slider.value = manaPercentage;
    }
}