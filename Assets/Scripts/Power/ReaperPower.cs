using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaperPower : ShootingPower
{
    [SerializeField] private int _audioIndex;
    private IDetectable _iDetectable;

    protected override void Awake()
    {
        base.Awake();
        _iDetectable = GetComponent<IDetectable>();
    }

    protected virtual void UpdateLaunchPointRotation()
    {
        Vector2 targetPosition = new Vector2(_iDetectable.Target.transform.position.x, -2);
        Vector2 characterPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 attackPointPosition = new Vector2(base._attackPoint.position.x, base._attackPoint.position.y);

        Vector2 horizontalDirection = characterPosition - targetPosition;
        Vector2 crossDirection = attackPointPosition - targetPosition;
        float angle = Vector2.SignedAngle(horizontalDirection, crossDirection);
        base._attackPoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    protected override void UsePower()
    {
        if (_iDetectable.Target != null)
        {
            UpdateLaunchPointRotation();
        }
        SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        base.UsePower();
    }
}
