using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour, IStats
{
    [SerializeField] private Stats _stats;
    private ManaBar _manaBar;
    private bool _canUsePower;
    private float _maxMana;
    private float _currentMana;
    private float _manaToAdd = 2;
    public float Mana
    {
        get => _currentMana;
        set
        {
            if (_currentMana != value)
            {
                _currentMana = value;
                ManaChangeAction();
            }
        }
    }
    public float Strength { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float MaxMana { get => _maxMana; set => _maxMana = value; }
    public bool CanUsePower { get => _canUsePower; set => _canUsePower = value; }
    public float ManaToAdd { get => _manaToAdd; set => _manaToAdd = value; }

    private void Awake()
    {
        _manaBar = GetComponentInChildren<ManaBar>();
    }

    private void OnEnable()
    {
        _canUsePower = false;
    }

    private void Start()
    {
        _maxMana = _stats.Mana;
        _currentMana = 0;
    }

    public void AddMana(float manaToAdd)
    {
        _currentMana += manaToAdd;
        ManaChangeAction();
        if (_currentMana >= _maxMana)
        {
            _canUsePower = true;
            _currentMana = 0;
        }
    }

    private void ManaChangeAction()
    {
        _manaBar.UpdateManaBar(_currentMana, _maxMana);
    }
}
