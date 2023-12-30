using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolemPower : Power
{
    [SerializeField] private float _existTime;
    [SerializeField] private GameObject _fireFlameEffect;
    [SerializeField] private Transform _powerLaunchPoint;
    [SerializeField] private int _audioIndex;

    private IEnumerator PlayEffectCoroutine()
    {
        SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        GameObject flameEffect = ObjectPoolManager.SpawnObject(_fireFlameEffect, _powerLaunchPoint.position, _powerLaunchPoint.rotation, ObjectPoolManager.PoolType.GameObject);
        yield return new WaitForSeconds(_existTime);
        flameEffect.GetComponent<Animator>().Play("Detonate", -1, 0f);
    }

    protected override void UsePower()
    {
        CoroutineManager.Instance.StartCoroutine(PlayEffectCoroutine());
    }
}
