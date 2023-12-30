using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : BaseSlider
{
    protected override void Start()
    {
        base.Start();
        slider.value = MusicManager.Instance._audioSource.volume;
    }

    protected override void OnValueChanged()
    {
        MusicManager.Instance._audioSource.volume = slider.value;
    }
}
