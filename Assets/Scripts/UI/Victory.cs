using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private Transform _starParent;
    private List<GameObject> _stars;
    private List<string> _wonLevels;

    private void OnEnable()
    {
        _wonLevels = LoadManager.Instance.LoadWonLevels();
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager is null");
        }
        GameManager.Instance.OnVictory += ShowVictoryPanel;
        GameManager.Instance.OnVictory += SaveWonLevel;
        GameManager.Instance.OnVictory += AddStar;
        GameManager.Instance.OnVictory += AddCoin;
        if (_starParent != null)
        {
            _stars = new List<GameObject>();
            for (int i = 0; i < _starParent.childCount; i++)
            {
                _stars.Add(_starParent.GetChild(i).gameObject);
            }
        }
    }

    private void OnDisable()
    {
        GameManager.Instance.OnVictory -= ShowVictoryPanel;
        GameManager.Instance.OnVictory -= SaveWonLevel;
        GameManager.Instance.OnVictory -= AddStar;
        GameManager.Instance.OnVictory -= AddCoin;
    }

    private void ShowVictoryPanel()
    {
        _victoryPanel.SetActive(true);
        StartCoroutine(ShowStar());
    }

    IEnumerator ShowStar()
    {
        for (int i = 0; i < _stars.Count; i++)
        {
            _stars[i].SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void SaveWonLevel()
    {
        _wonLevels.Add(SceneManager.GetActiveScene().name);
        SaveManager.Instance.SaveWonLevels(_wonLevels);
    }

    private void AddStar()
    {
        int currentStar = LoadManager.Instance.LoadStars();
        foreach (Level level in _levelData.Level)
        {
            if (level.LevelName == SceneManager.GetActiveScene().name)
            {
                currentStar += level.StarEarnings;
            }
        }
        SaveManager.Instance.SaveStars(currentStar);
    }

    private void AddCoin()
    {
        int currentCoin = LoadManager.Instance.LoadGold();
        foreach (Level level in _levelData.Level)
        {
            if (level.LevelName == SceneManager.GetActiveScene().name)
            {
                currentCoin += level.CoinEarnings;
                Debug.Log(currentCoin);
            }
        }
        SaveManager.Instance.SaveGold(currentCoin);
    }
}
