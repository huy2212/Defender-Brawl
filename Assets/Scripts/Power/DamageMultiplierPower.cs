using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageMultiplierPower : Power
{
    [SerializeField] protected float _damageMultiplier;
    protected GameObject _target;
    protected float _damage;
    protected float _multipliedDamage;
    protected float _originalDamage;

    protected virtual void Start()
    {
        this._damage = GetComponent<IAttackable>().Damage;
        _multipliedDamage = _damage * _damageMultiplier;
        _originalDamage = _damage;
    }

    public override void StartPower()
    {
        base.StartPower();
        this._damage = _multipliedDamage;
    }

    protected override void EndPower()
    {
        base.EndPower();
        this._damage = _originalDamage;
    }

    protected override void UsePower()
    {
        _target = GetComponent<IDetectable>().Target;
        _target.GetComponent<IDamageable>().TakeDamage(this._damage);
        this._damage /= _damageMultiplier;
    }
}
