using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour, ICritical
{
    [SerializeField] private CriticalData _criticalData;
    private float _criticalHitChance;
    private float _criticalHitMultiplier;
    public float CriticalHitChance { get => _criticalHitChance; set => _criticalHitChance = value; }
    public float CriticalHitMultiplier { get => _criticalHitMultiplier; set => _criticalHitMultiplier = value; }

    private void Awake()
    {
        _criticalHitChance = _criticalData.CriticalHitChance;
        _criticalHitMultiplier = _criticalData.CriticalHitMultiplier;
    }

    public bool IsCritical()
    {
        return Random.Range(0f, 1f) <= _criticalHitChance;
    }
}
