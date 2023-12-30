using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public static LoadManager Instance { get; private set; }

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

    public float LoadMusicVolume()
    {
        return PlayerPrefs.GetFloat("MusicVolume", 100);
    }

    public bool LoadIsMusicOn()
    {
        return PlayerPrefs.GetInt("IsMusicOn", 1) == 1;
    }

    public float LoadSoundVolume()
    {
        return PlayerPrefs.GetFloat("SoundVolume", 100);
    }

    public bool LoadIsSoundOn()
    {
        return PlayerPrefs.GetInt("IsSoundOn", 1) == 1;
    }

    public string LoadName()
    {
        return PlayerPrefs.GetString("PlayerName");
    }

    public int LoadGold()
    {
        return PlayerPrefs.GetInt("Gold", 0);
    }

    public int LoadEnergy()
    {
        return PlayerPrefs.GetInt("Energy", 0);
    }

    public int LoadStars()
    {
        return PlayerPrefs.GetInt("Stars", 0);
    }

    public List<string> LoadOwnedItems()
    {
        string ownedItemsString = PlayerPrefs.GetString("OwnedItems");
        List<string> ownedItems = new List<string>();
        if (ownedItemsString != "")
        {
            ownedItems = new List<string>(ownedItemsString.Split(','));
        }
        return ownedItems;
    }

    public List<string> LoadWonLevels()
    {
        string wonLevelsString = PlayerPrefs.GetString("WonLevels");
        List<string> wonLevels = new List<string>();
        if (wonLevelsString != "")
        {
            wonLevels = new List<string>(wonLevelsString.Split(','));
        }
        return wonLevels;
    }
}
