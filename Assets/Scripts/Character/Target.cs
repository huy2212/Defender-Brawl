using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable, IHealth
{
    [SerializeField] private HealthData _healthData;
    private Animator _animator;
    private HealthBar _healthBar;
    private float _health;
    private float _maxHealth;
    private GameObject _attacker;
    public event Action OnDie;
    public event Action OnDamageTaken;
    public bool IsDead => _health <= 0;
    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            InvokeOnHealthChanged();
        }
    }

    public GameObject Attacker { get => _attacker; set => _attacker = value; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _healthBar = GetComponentInChildren<HealthBar>();
    }

    private void Start()
    {
        SetCurrentHealth(_healthData.Health);
        SetMaxHealth(_healthData.Health);
    }

    public void TakeDamage(float damage)
    {
        OnDamageTaken?.Invoke();
        Vector3 damagePosition = RandomDamagePosition();
        PopupManager.Instance.ShowDamagePopup(damage, PopupType.DamagePopup, damagePosition);
        this.Health -= damage;
        // _healthBar?.UpdateHealthBar(_health, _maxHealth);
        if (_health <= 0)
        {
            Dying();
        }
    }

    private void Dying()
    {
        OnDie?.Invoke();
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void AddHealth(float amount)
    {
        this.Health += amount;
        Vector3 healPosition = RandomDamagePosition();
        PopupManager.Instance.ShowDamagePopup(amount, PopupType.HealPopup, healPosition);
    }

    public void SetCurrentHealth(float health)
    {
        _health = health;
    }

    public void SetMaxHealth(float maxHealth)
    {
        _maxHealth = maxHealth;
    }

    private void InvokeOnHealthChanged()
    {
        _healthBar?.UpdateHealthBar(_health, _maxHealth);
    }

    private Vector3 RandomDamagePosition()
    {
        float x = transform.position.x + UnityEngine.Random.Range(0.5f, 1.5f);
        float y = transform.position.y + UnityEngine.Random.Range(1.5f, 2.5f);
        return new Vector3(x, y, 0);
    }

    public void TakeCriticalDamage(float damage)
    {
        OnDamageTaken?.Invoke();
        Vector3 damagePosition = RandomDamagePosition();
        PopupManager.Instance.ShowDamagePopup(damage, PopupType.CriticalPopup, damagePosition);
        this.Health -= damage;
        // _healthBar?.UpdateHealthBar(_health, _maxHealth);
        if (_health <= 0)
        {
            Dying();
        }
    }
}
