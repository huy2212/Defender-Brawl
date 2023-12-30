using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleSoundButton : BaseButton
{
    [SerializeField] private GameObject _soundOnImage;
    [SerializeField] private GameObject _soundOffImage;
    [SerializeField] private Slider _soundSlider;

    protected override void OnClick()
    {
        this.SoundToggleHandler(SoundManager.Instance.IsSoundOn);
    }

    public void SoundToggleHandler(bool isSoundOn)
    {
        if (isSoundOn)
        {
            SoundManager.Instance.StopSound();
            _soundOnImage.SetActive(false);
            _soundOffImage.SetActive(true);
            _soundSlider.interactable = false;
        }
        else
        {
            SoundManager.Instance.ContinueSound();
            _soundOnImage.SetActive(true);
            _soundOffImage.SetActive(false);
            _soundSlider.interactable = true;
        }
    }
}
