using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcPower : Power
{
    [SerializeField] private float _healthAmount;
    [SerializeField] private int _audioIndex;
    private IAttackable _iAttackable;

    protected override void Awake()
    {
        base.Awake();
        _iAttackable = GetComponent<IAttackable>();
    }

    protected override void UsePower()
    {
        float damage = _iAttackable.Damage;
        GameObject target = GetComponent<IDetectable>().Target;
        if (target != null)
        {
            SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
            target.GetComponent<IDamageable>().TakeDamage(damage);
            this.GetComponent<IHealth>().AddHealth(_healthAmount);
        }
    }
}
