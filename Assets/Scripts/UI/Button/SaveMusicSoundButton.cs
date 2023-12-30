using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SaveMusicSoundButton : BaseButton
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Button _isMusicOnButton;
    [SerializeField] private Button _isSoundOnButton;

    protected override void OnClick()
    {
        SaveManager.Instance?.SaveMusicVolume(MusicManager.Instance._audioSource.volume);
        SaveManager.Instance?.SaveSoundVolume(SoundManager.Instance._audioSource.volume);
        SaveManager.Instance?.SaveIsMusicOn(MusicManager.Instance.IsMusicOn);
        SaveManager.Instance?.SaveIsSoundOn(SoundManager.Instance.IsSoundOn);
    }
}
