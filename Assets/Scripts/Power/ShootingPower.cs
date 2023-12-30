using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPower : Power, ILauncher
{
    [SerializeField] protected GameObject _bulletPrefab;
    [SerializeField] protected Transform _attackPoint;

    public GameObject Projectile { get => _bulletPrefab; set => _bulletPrefab = value; }

    public void Launch(Transform weapon)
    {
        ObjectPoolManager.SpawnObject(_bulletPrefab, weapon.position, weapon.rotation, ObjectPoolManager.PoolType.GameObject);
        _bulletPrefab.GetComponent<IBullet>().Launcher = this.gameObject;
    }

    protected override void UsePower()
    {
        Launch(_attackPoint);
    }
}
