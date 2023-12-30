using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private GameObject _settingPanel;
    [SerializeField] private Button _settingButton;
    private ToggleMusicButton _toggleMusicButton;
    private ToggleSoundButton _toggleSoundButton;
    private Slider _musicSlider;
    private Slider _soundSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        SetupSound();
        SetupMusic();
    }

    private void SetupSound()
    {
        _toggleMusicButton = _settingPanel.transform.Find("MusicButton").gameObject.GetComponent<ToggleMusicButton>();
        _musicSlider = _settingPanel.transform.Find("MusicSlider").gameObject.GetComponent<Slider>();
    }

    private void SetupMusic()
    {
        _toggleSoundButton = _settingPanel.transform.Find("SoundButton").gameObject.GetComponent<ToggleSoundButton>();
        _soundSlider = _settingPanel.transform.Find("SoundSlider").gameObject.GetComponent<Slider>();
    }
}
