using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : MonoBehaviour
{
    [SerializeField] protected Slider slider;

    protected virtual void OnValidate()
    {
        if (slider == null)
        {
            slider = GetComponent<Slider>();
        }
    }

    protected virtual void Start()
    {
        this.AddOnValueChangedEvent();
    }

    protected virtual void AddOnValueChangedEvent()
    {
        this.slider.onValueChanged.AddListener(value => this.OnValueChanged());
    }

    protected abstract void OnValueChanged();
}
