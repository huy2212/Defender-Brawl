using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemFlame : MonoBehaviour
{
    [SerializeField] private float _damagePerAttack;
    [SerializeField] private float _attackDelayTime;
    [SerializeField] private LayerMask _targetLayer;
    private Collider2D[] _targets = new Collider2D[20];

    private void OnEnable()
    {
        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            int count = Physics2D.OverlapBoxNonAlloc(transform.position, transform.localScale, 0f, _targets, _targetLayer);
            for (int i = 0; i < count; i++)
            {
                _targets[i].GetComponent<IDamageable>()?.TakeDamage(_damagePerAttack);
            }
            yield return new WaitForSeconds(_attackDelayTime);
        }
    }

    public void Disable()
    {
        StopAllCoroutines();
        this.gameObject.SetActive(false);
    }
}
