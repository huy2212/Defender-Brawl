using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defeat : MonoBehaviour
{
    [SerializeField] private GameObject _defeatPanel;

    private void OnEnable()
    {
        GameManager.Instance.OnDefeat += ShowDefeatPanel;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnDefeat -= ShowDefeatPanel;
    }

    private void ShowDefeatPanel()
    {
        _defeatPanel.SetActive(true);
    }
}
