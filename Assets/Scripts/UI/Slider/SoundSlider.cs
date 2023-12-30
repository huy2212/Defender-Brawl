using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSlider : BaseSlider
{
    protected override void Start()
    {
        base.Start();
        slider.value = LoadManager.Instance.LoadSoundVolume();
    }

    protected override void OnValueChanged()
    {
        SoundManager.Instance._audioSource.volume = slider.value;
    }
}
