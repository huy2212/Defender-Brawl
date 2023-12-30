using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IAttackable
{
    [SerializeField] private AttackData _attackData;
    [SerializeField] private int _audioIndex;
    private Transform _attackPoint;
    private Animator _animator;
    private IStats _iStats;
    private IDetectable _iDetectable;
    private IDamageable _iDamageable;
    private Power _power;
    private float _range;
    private float _damage;
    private float _attackDelayTime;
    private float _nextAttackTime = 0;
    public float Damage
    {
        get => _damage;
        set => _damage = value;
    }
    public float AttackDelayTime
    {
        get => _attackDelayTime;
        set => _attackDelayTime = value;
    }
    bool IAttackable.CanAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private void Awake()
    {
        _attackPoint = transform.Find("AttackPoint").transform;
        _animator = GetComponent<Animator>();
        _iDetectable = GetComponent<IDetectable>();
        _iDamageable = GetComponent<IDamageable>();
        _iStats = GetComponent<IStats>();
        _power = GetComponent<Power>();
        _damage = _attackData.Damage;
        _attackDelayTime = _attackData.AttackDelayTime;
        _range = _attackData.Range;
    }

    private void Update()
    {
        GameObject target = _iDetectable.Target;
        if (target != null)
        {
            if (CanAttack())
            {
                _nextAttackTime = Time.time + _attackDelayTime;
                Attack(target);
            }
        }
    }

    public void Fire()
    {
        GetComponent<ILauncher>().Launch(_attackPoint);
    }

    public void Attack(GameObject target)
    {
        if (_iStats.CanUsePower)
        {
            _power.StartPower();
        }
        else
        {
            Fire();
            _animator.SetTrigger("Attack");
            SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        }
    }

    protected virtual bool CanAttack()
    {
        return Time.time >= _nextAttackTime && !_iDamageable.IsDead;
    }
}
