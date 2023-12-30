using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }
    [SerializeField] private List<TMP_Text> _goldText;
    [SerializeField] private GameObject _notEnoughGoldText;
    private int _gold;
    public int Gold
    {
        get => _gold;
        set
        {
            _gold = value;
            SetGoldText();
        }
    }
    public event System.Action OnBuySuccess;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }
    }

    private void Start()
    {
        _gold = LoadManager.Instance.LoadGold();
        SetGoldText();
    }

    public void AddGold(int gold)
    {
        _gold += gold;
        SetGoldText();
        SaveManager.Instance.SaveGold(_gold);
    }

    public bool SubtractGold(int gold)
    {
        if (_gold - gold < 0)
        {
            _notEnoughGoldText.SetActive(true);
            return false;
        }
        OnBuySuccess?.Invoke();
        _gold -= gold;
        SetGoldText();
        SaveManager.Instance.SaveGold(_gold);
        return true;
    }

    private void SetGoldText()
    {
        foreach (var text in _goldText)
        {
            text.text = _gold.ToString();
        }
    }
}
