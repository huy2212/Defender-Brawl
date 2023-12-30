using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Action = System.Action;
using System;
public class GhostSpell : MonoBehaviour, IAttackable
{
    [SerializeField] private AttackData _attackData;
    private float _timeExist = 4f;
    private float _damage;
    private Collider2D[] _targetList = new Collider2D[20];
    private LayerMask _targetLayer;
    private GameObject _launcher;
    private float _attackDelayTime;
    private IBullet _iBullet;
    private bool _isAttacking = false;
    public float Damage { get => _damage; set => _damage = value; }
    public float AttackDelayTime { get => _attackDelayTime; set => _attackDelayTime = value; }
    public bool CanAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private void Awake()
    {
        _iBullet = GetComponent<IBullet>();
    }

    private void OnEnable()
    {
        _isAttacking = false;
    }

    private void Start()
    {
        _attackDelayTime = _attackData.AttackDelayTime;
        _launcher = _iBullet.Launcher;
        _damage = _attackData.Damage;
        _targetLayer = _attackData.TargetLayer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            StartCoroutine(ObjectPoolManager.ReturnObjectToPool(gameObject, _timeExist));
            StartCoroutine(AttackTargetCoroutine());
        }
    }

    private IEnumerator AttackTargetCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<IMoveable>().CanMove = false;

        float elapsedTime = 0f;
        while (elapsedTime < _timeExist)
        {
            if (!_isAttacking)
            {
                _isAttacking = true;
                yield return new WaitForSeconds(_attackDelayTime);
                Attack();
                elapsedTime += _attackDelayTime;
                _isAttacking = false;
            }
            else
            {
                yield return null;
            }
        }
        ObjectPoolManager.ReturnObjectToPool(this.gameObject);
    }

    public void Attack(GameObject target = null)
    {
        Array.Clear(_targetList, 0, _targetList.Length);
        int numberColliders = Physics2D.OverlapCircleNonAlloc(transform.position, _attackData.Range, _targetList, _targetLayer);
        for (int i = 0; i < numberColliders; i++)
        {
            // Loop through all colliders and make target take damage
            var damageable = _targetList[i].GetComponent<IDamageable>();
            damageable.Attacker = _launcher;
            damageable.TakeDamage(_damage);
        }
    }
}
