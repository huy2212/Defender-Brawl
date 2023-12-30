using System;
using UnityEngine;

public class BulletAttackMultiple : MonoBehaviour, IAttackable
{
    [SerializeField] private AttackData _attackData;
    private float _damage;
    private LayerMask _targetLayer;
    private GameObject _launcher;
    private IBullet _iBullet;
    public float Damage { get => _damage; set => _damage = value; }
    public float AttackDelayTime { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public bool CanAttack { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    private void Awake()
    {
        _iBullet = GetComponent<IBullet>();
    }

    private void Start()
    {
        _damage = _attackData.Damage;
        _targetLayer = _attackData.TargetLayer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            GameObject target = other.gameObject;
            _launcher = _iBullet.Launcher;
            target.GetComponent<IDamageable>().Attacker = _launcher;
            Attack(target);
        }
    }

    public void Attack(GameObject target)
    {
        target?.GetComponent<IDamageable>()?.TakeDamage(_damage);
    }
}
