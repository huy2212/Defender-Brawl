using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLauncher : MonoBehaviour, ILauncher
{
    [SerializeField] private GameObject _bulletPrefab;
    public GameObject Projectile { get => _bulletPrefab; set => _bulletPrefab = value; }

    public void Launch(Transform weapon)
    {
        ObjectPoolManager.SpawnObject(_bulletPrefab, weapon.position, weapon.rotation, ObjectPoolManager.PoolType.GameObject);
        _bulletPrefab.GetComponent<IBullet>().Launcher = this.gameObject;
    }
}
