using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    buttonClick = 0,
    darkMageAttack = 1,
    darkMageSkill = 2,
    grayFighterAttack = 3,
    grayFighterSkill = 4,
    minotaurAttack = 5,
    minotaurSkill = 6,
    reaperAttack = 7,
    reaperSkill = 8,
    ghostAttack = 9,
    ghostSkill = 10,
    fireGolemAttack = 11,
    fireGolemSkill = 12,
    iceGolemAttack = 13,
    iceGolemSkill = 14,
    orcAttack = 15,
    orcSkill = 16
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public AudioSource _audioSource;
    public bool IsSoundOn => !_audioSource.mute;

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
        _audioSource.volume = LoadManager.Instance.LoadSoundVolume();
        _audioSource.mute = !LoadManager.Instance.LoadIsSoundOn();
    }

    private void OnValidate()
    {
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void OnPlaySound(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Sounds/{soundType.ToString()}");
        _audioSource.PlayOneShot(audio);
    }

    public void PlayOneShotWithTime(SoundType soundType, float time)
    {
        StartCoroutine(PlayOneShotWithTimeCoroutine(soundType, time));
    }

    private IEnumerator PlayOneShotWithTimeCoroutine(SoundType soundType, float time)
    {
        var audio = Resources.Load<AudioClip>($"Sounds/{soundType.ToString()}");
        _audioSource.PlayOneShot(audio);
        yield return new WaitForSeconds(time);
        _audioSource.Stop();
    }

    public void ContinueSound()
    {
        _audioSource.mute = false;
    }

    public void StopSound()
    {
        _audioSource.mute = true;
    }
}
