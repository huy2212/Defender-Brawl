using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spriter2UnityDX;

public class IceGolemPower : Power
{
    [SerializeField] private float _attackSpeedMultiplier;
    [SerializeField] private float _decreaseTime;
    [SerializeField] private int _audioIndex;
    private IDetectable _iDetectable;
    private GameObject _target;

    protected override void Awake()
    {
        base.Awake();
        _iDetectable = GetComponent<IDetectable>();
    }


    private IEnumerator DecreaseAttackSpeed()
    {
        _target = _iDetectable.Target;
        if (_target != null && _target.GetComponent<IAttackable>() != null)
        {
            _target.GetComponent<IAttackable>().AttackDelayTime /= _attackSpeedMultiplier;
            yield return new WaitForSeconds(_decreaseTime);
            if (_target != null)
                _target.GetComponent<IAttackable>().AttackDelayTime *= _attackSpeedMultiplier;
        }
    }

    private IEnumerator ChangeTargetColor()
    {
        _target = _iDetectable.Target;
        if (_target != null && _target.GetComponent<EntityRenderer>() != null)
        {
            _target.GetComponent<EntityRenderer>().Color = new Color(128 / 255f, 255 / 255f, 255 / 255f);
            yield return new WaitForSeconds(_decreaseTime);
            _target.GetComponent<EntityRenderer>().Color = new Color(255 / 255f, 255 / 255f, 255 / 255f);
        }
    }
    protected override void UsePower()
    {
        SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        CoroutineManager.Instance.StartManagedCoroutine(DecreaseAttackSpeed());
        CoroutineManager.Instance.StartManagedCoroutine(ChangeTargetColor());
    }
}
