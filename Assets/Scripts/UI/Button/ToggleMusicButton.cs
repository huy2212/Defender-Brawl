using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMusicButton : BaseButton
{
    [SerializeField] private GameObject _musicOnImage;
    [SerializeField] private GameObject _musicOffImage;
    [SerializeField] private Slider _musicSlider;

    protected override void OnClick()
    {
        this.MusicToggleHandler(MusicManager.Instance.IsMusicOn);
    }

    public void MusicToggleHandler(bool isMusicOn)
    {
        if (isMusicOn)
        {
            MusicManager.Instance.StopMusic();
            _musicOnImage.SetActive(false);
            _musicOffImage.SetActive(true);
            _musicSlider.interactable = false;
        }
        else
        {
            MusicManager.Instance.ContinueMusic();
            _musicOnImage.SetActive(true);
            _musicOffImage.SetActive(false);
            _musicSlider.interactable = true;
        }
    }
}
