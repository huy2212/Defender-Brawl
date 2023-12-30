using UnityEngine;

public interface IDamageable
{
    bool IsDead { get; }
    GameObject Attacker { get; set; }
    void TakeDamage(float damage);
    void TakeCriticalDamage(float damage);
    event System.Action OnDie;
    void Die();
    event System.Action OnDamageTaken;
}