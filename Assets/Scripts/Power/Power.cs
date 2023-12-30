using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Power : MonoBehaviour
{
    [SerializeField] protected int _powerTimes;
    protected IStats _istats;
    protected Animator _animator;
    protected int _defaultPowerTimes;

    protected virtual void Awake()
    {
        _istats = GetComponent<IStats>();
        _animator = GetComponent<Animator>();
        _defaultPowerTimes = _powerTimes;
    }

    protected abstract void UsePower();

    public virtual void StartPower()
    {
        _istats.Mana = 0;
        ContinuePower();
    }

    protected virtual void EndPower()
    {
        _istats.CanUsePower = false;
        _powerTimes = _defaultPowerTimes;
    }

    protected virtual void ContinuePower()
    {
        _animator.SetTrigger("Power");
        UsePower();
        _powerTimes--;
        if (_powerTimes <= 0)
        {
            EndPower();
        }
    }
}
