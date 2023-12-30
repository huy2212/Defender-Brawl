using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadWonLevels : MonoBehaviour
{
    [SerializeField] private List<Button> _levelButtons;

    private void OnEnable()
    {
        LoadWonLevel();
    }

    private void LoadWonLevel()
    {
        List<string> wonLevels = LoadManager.Instance.LoadWonLevels();
        for (int i = 1; i < _levelButtons.Count; i++)
        {
            if (wonLevels.Contains(_levelButtons[i - 1].name))
            {
                _levelButtons[i].interactable = true;
            }
            else
            {
                break;
            }
        }
    }
}
