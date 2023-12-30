using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dying : MonoBehaviour
{
    private IDamageable _iDamageable;

    private void Awake()
    {
        _iDamageable = GetComponent<IDamageable>();
    }

    private void OnEnable()
    {
        _iDamageable.OnDie += DisableCollider;
        _iDamageable.OnDie += DisableCanvas;
        _iDamageable.OnDie += PlayDieAnimation;
    }

    private void OnDisable()
    {
        _iDamageable.OnDie -= PlayDieAnimation;
        _iDamageable.OnDie -= DisableCollider;
        _iDamageable.OnDie -= DisableCanvas;
    }

    private void PlayDieAnimation()
    {
        Animator animator = GetComponent<Animator>();
        animator?.SetTrigger("Die");
    }

    private void DisableCollider()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        if (collider2D != null)
        {
            collider2D.enabled = false;
        }
    }

    private void DisableCanvas()
    {
        Canvas canvas = GetComponentInChildren<Canvas>();
        if (canvas != null)
        {
            canvas.enabled = false;
        }
    }
}
