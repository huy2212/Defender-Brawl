using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet, IPoolable
{
    private bool _isPooled = false;
    private static GameObject _launcher;
    public GameObject Launcher { get => _launcher; set => _launcher = value; }
    public bool IsPooled { get => _isPooled; set => _isPooled = value; }
}