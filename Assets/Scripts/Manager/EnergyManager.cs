using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EnergyManager : MonoBehaviour
{
    public static EnergyManager Instance { get; private set; }
    [SerializeField] private List<TMP_Text> _energyText;
    [SerializeField] private GameObject _notEnoughEnergyText;
    private int _energy;

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
        _energy = LoadManager.Instance.LoadEnergy();
        SetEnergyText();
    }

    public void AddEnergy(int energy)
    {
        _energy += energy;
        SetEnergyText();
        SaveManager.Instance.SaveEnergy(_energy);
    }

    public void SubtractEnergy(int energy)
    {
        if (_energy - energy < 0)
        {
            _notEnoughEnergyText.SetActive(true);
            return;
        }
        _energy -= energy;
        SetEnergyText();
        SaveManager.Instance.SaveEnergy(_energy);
    }

    private void SetEnergyText()
    {
        foreach (var text in _energyText)
        {
            text.text = _energy.ToString();
        }
    }
}
