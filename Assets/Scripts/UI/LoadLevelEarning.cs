using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelEarning : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    [SerializeField] private string _levelName;
    [SerializeField] private TMP_Text _starEarningsText;
    [SerializeField] private TMP_Text _coinEarningsText;

    private void OnEnable()
    {
        _levelName = SceneManager.GetActiveScene().name;
        LoadEarnings();
    }

    public void LoadEarnings()
    {
        foreach (Level level in _levelData.Level)
        {
            if (level.LevelName == _levelName)
            {
                _starEarningsText.text = level.StarEarnings.ToString();
                _coinEarningsText.text = level.CoinEarnings.ToString();
            }
        }
    }
}
