using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

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

    public void SaveMusicVolume(float musicVolume)
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SaveIsMusicOn(bool isMusicOn)
    {
        PlayerPrefs.SetInt("IsMusicOn", isMusicOn ? 1 : 0);
    }

    public void SaveSoundVolume(float soundVolume)
    {
        PlayerPrefs.SetFloat("SoundVolume", soundVolume);
    }

    public void SaveIsSoundOn(bool isSoundOn)
    {
        PlayerPrefs.SetInt("IsSoundOn", isSoundOn ? 1 : 0);
    }

    public void SaveName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }

    public void SaveGold(int gold)
    {
        PlayerPrefs.SetInt("Gold", gold);
    }

    public void SaveEnergy(int energy)
    {
        PlayerPrefs.SetInt("Energy", energy);
    }

    public void SaveStars(int stars)
    {
        PlayerPrefs.SetInt("Stars", stars);
    }

    public void SaveOwnedItems(List<string> ownedItems)
    {
        string ownedItemsString = string.Join(",", ownedItems.ToArray());
        PlayerPrefs.SetString("OwnedItems", ownedItemsString);
    }

    public void SaveWonLevels(List<string> wonLevels)
    {
        string wonLevelsString = string.Join(",", wonLevels.ToArray());
        PlayerPrefs.SetString("WonLevels", wonLevelsString);
    }
}
