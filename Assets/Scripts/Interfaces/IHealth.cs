using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    public float Health { get; set; }
    public void SetMaxHealth(float maxHealth);
    public void SetCurrentHealth(float health);
    public void AddHealth(float amount);
}
