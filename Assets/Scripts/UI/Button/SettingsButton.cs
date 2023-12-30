using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : BaseButton
{
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundSlider;
    [SerializeField] private Button _musicButton;
    [SerializeField] private Button _soundButton;

    protected override void OnClick()
    {
        _musicSlider.value = LoadManager.Instance.LoadMusicVolume();
        _soundSlider.value = LoadManager.Instance.LoadSoundVolume();

        // Set up music button
        if (LoadManager.Instance.LoadIsMusicOn())
        {
            _musicButton.GetComponent<ToggleMusicButton>().MusicToggleHandler(false);
            MusicManager.Instance?.ContinueMusic();
        }
        else
        {
            _musicButton.GetComponent<ToggleMusicButton>().MusicToggleHandler(true);
            MusicManager.Instance?.StopMusic();
        }

        // Set up sound button
        if (LoadManager.Instance.LoadIsSoundOn())
        {
            _soundButton.GetComponent<ToggleSoundButton>().SoundToggleHandler(false);
            SoundManager.Instance?.ContinueSound();
        }
        else
        {
            _soundButton.GetComponent<ToggleSoundButton>().SoundToggleHandler(true);
            SoundManager.Instance?.StopSound();
        }
    }
}
