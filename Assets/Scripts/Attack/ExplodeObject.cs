using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeObject : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _damage;
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private LayerMask _targetLayer;
    [SerializeField] private Transform _explosionPoint;
    private Collider2D[] _colliders = new Collider2D[20];

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_targetLayer == (_targetLayer | (1 << other.gameObject.layer)))
        {
            GameObject target = other.gameObject;
            Explode();
        }
    }

    private void Explode()
    {
        Vector2 explosionPos = new Vector2(_explosionPoint.position.x, 0.2f);
        GameObject explosion = ObjectPoolManager.SpawnObject(_explosionEffect, explosionPos, Quaternion.identity, ObjectPoolManager.PoolType.GameObject);

        int count = Physics2D.OverlapCircleNonAlloc(_explosionPoint.position, _explodeRadius, _colliders, _targetLayer);
        for (int i = 0; i < count; i++)
        {
            _colliders[i].GetComponent<IDamageable>()?.TakeDamage(_damage);
        }

        CoroutineManager.Instance.StartCoroutine(ObjectPoolManager.ReturnObjectToPool(explosion, 0.5f));
    }

    private void OnDrawGizmos()
    {
        if (_explosionPoint != null)
        {
            Gizmos.DrawWireSphere(_explosionPoint.position, _explodeRadius);
        }
    }
}
