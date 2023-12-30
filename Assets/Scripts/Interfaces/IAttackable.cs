using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackable
{
    bool CanAttack { get; set; }
    float Damage { get; set; }
    float AttackDelayTime { get; set; }
    void Attack(GameObject target);
}
