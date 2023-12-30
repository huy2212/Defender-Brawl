using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MusicType
{
    startingSceneMusic = 0,
    loginSceneMusic = 1,
    mainMenuMusic = 2,
    inBattleMusic = 3,
}

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    public AudioSource _audioSource;
    public bool IsMusicOn => !_audioSource.mute;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        _audioSource.mute = !LoadManager.Instance.LoadIsMusicOn();
        _audioSource.volume = LoadManager.Instance.LoadMusicVolume();
        _audioSource.loop = true;
        if (LoadingManager.Instance != null)
        {
            LoadingManager.Instance.OnSceneLoaded += ChangeMusicTypeOnLoad;
        }
        OnPlayMusic(MusicType.startingSceneMusic.GetHashCode());
    }

    private void OnValidate()
    {
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.playOnAwake = true;
        }
    }

    public void OnPlayMusic(int musicIndex)
    {
        MusicType musicType = (MusicType)musicIndex;
        var audio = Resources.Load<AudioClip>($"Musics/{musicType.ToString()}");
        _audioSource.clip = audio;
        _audioSource.Play();
    }

    public void ContinueMusic()
    {
        _audioSource.mute = false;
    }

    public void StopMusic()
    {
        _audioSource.mute = true;
    }

    public void ChangeMusicTypeOnLoad(int sceneIndex)
    {
        int musicIndex;
        if (sceneIndex > MusicType.inBattleMusic.GetHashCode())
        {
            musicIndex = MusicType.inBattleMusic.GetHashCode();
        }
        else
        {
            musicIndex = sceneIndex;
        }
        OnPlayMusic(musicIndex);
    }
}
