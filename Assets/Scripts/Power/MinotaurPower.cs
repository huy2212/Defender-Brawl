using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MinotaurPower : Power
{
    [SerializeField] private GameObject _attackPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private float _speedMultiplier;
    [SerializeField] private int _audioIndex;
    private ITurnable _iTunrable;
    private Collider2D[] hitEnemies = new Collider2D[10];

    protected override void Awake()
    {
        base.Awake();
        _iTunrable = GetComponent<ITurnable>();
    }

    private IEnumerator DealDamage()
    {
        Array.Clear(hitEnemies, 0, hitEnemies.Length);
        int numberOfEnemies = Physics2D.OverlapCircleNonAlloc(_attackPoint.transform.position, _attackPoint.GetComponent<CircleCollider2D>().radius, hitEnemies, _enemyLayer);
        if (numberOfEnemies > 0)
        {
            for (int i = 0; i < numberOfEnemies; i++)
            {
                hitEnemies[i].GetComponent<IDamageable>().TakeDamage(_damage);
            }
            yield return new WaitForSeconds(0.5f);
            EndPower();
        }
    }

    public override void StartPower()
    {
        base.StartPower();
        GetComponent<IMoveable>().MoveSpeed *= _speedMultiplier;
        GetComponent<IAttackable>().CanAttack = false;
    }

    protected override void UsePower()
    {
        SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        StartCoroutine(DealDamage());
    }

    protected override void EndPower()
    {
        base.EndPower();
        AnimatorClipInfo[] clipInfo = _animator.GetCurrentAnimatorClipInfo(0);
        if (clipInfo.Length > 0 && clipInfo[0].clip.name != "Dying")
        {
            _animator.Play("Idle", -1, 0.1f);
        }
        GetComponent<IMoveable>().MoveSpeed /= _speedMultiplier;
        GetComponent<IAttackable>().CanAttack = true;
    }

    protected override void ContinuePower()
    {
        _animator.SetTrigger("Power");
        UsePower();
        _powerTimes--;
    }
}
