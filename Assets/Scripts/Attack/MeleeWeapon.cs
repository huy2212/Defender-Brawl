using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IAttackable
{
    [SerializeField] private AttackData _attackData;
    [SerializeField] private int _audioIndex;
    private ManaBar _manaBar;
    private Animator _animator;
    private IDetectable _iDetectable;
    private IDamageable _iDamageable;
    private IStats _iStats;
    private Power _power;
    private ICritical _iCritical;
    private bool _canAttack = true;
    private float _damage;
    private float _mana = 0;
    private float _maxMana;
    private float _attackDelayTime;
    private float _nextAttackTime = 0;
    public bool CanAttack
    {
        get => _canAttack;
        set => _canAttack = value;
    }

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
    public float Mana { get => _mana; set => _mana = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _iDetectable = GetComponent<IDetectable>();
        _iDamageable = GetComponent<IDamageable>();
        _manaBar = GetComponentInChildren<ManaBar>();
        _iStats = GetComponent<IStats>();
        _power = GetComponent<Power>();
        _iCritical = GetComponent<ICritical>();
        _damage = _attackData.Damage;
        _attackDelayTime = _attackData.AttackDelayTime;
    }

    private void LateUpdate()
    {
        GameObject target = _iDetectable.Target;
        if (target != null)
        {
            if (CanAttackAgain())
            {
                _nextAttackTime = Time.time + _attackDelayTime;
                Attack(target);
                target.GetComponent<IDamageable>().Attacker = this.gameObject;
            }
        }
    }

    public void Attack(GameObject target)
    {
        if (_iStats.CanUsePower)
        {
            _power.StartPower();
        }
        else
        {
            if (_iCritical != null && _iCritical.IsCritical())
            {
                target.GetComponent<IDamageable>().TakeCriticalDamage(_damage * _iCritical.CriticalHitMultiplier);
            }
            else
            {
                target.GetComponent<IDamageable>().TakeDamage(_damage);
            }
            _animator.SetTrigger("Attack");
            SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
            _iStats.AddMana(_iStats.ManaToAdd);
            _manaBar?.UpdateManaBar(_iStats.Mana, _iStats.MaxMana);
        }
    }

    protected virtual bool CanAttackAgain()
    {
        return Time.time >= _nextAttackTime && !_iDamageable.IsDead && _canAttack;
    }
}
