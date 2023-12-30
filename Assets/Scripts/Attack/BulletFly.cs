using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour, IMoveable
{
    [SerializeField] private SpeedData _speedData;
    private bool _canMove;
    private float _flyDistance;
    private float _moveSpeed;
    private float _baseMoveSpeed;
    private bool _isFacingRight = true;
    public bool CanMove { get => _canMove; set => _canMove = value; }
    public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
    public bool IsFacingRight { get; set; }

    private void Awake()
    {
        _moveSpeed = _speedData.MoveSpeed;
        _flyDistance = _speedData.Distance;
    }
    private void Start()
    {
        _baseMoveSpeed = _moveSpeed;
    }

    private void OnEnable()
    {
        _canMove = true;
    }

    private void Update()
    {
        if (_canMove)
        {
            if (_isFacingRight)
            {
                MoveForward();
            }
            else
            {
                MoveBackward();
            }
        }
    }

    public void MoveBackward()
    {
        transform.Translate(Vector2.left * _moveSpeed * Time.deltaTime, Space.Self);
    }

    public void MoveForward()
    {
        transform.Translate(Vector2.right * _moveSpeed * Time.deltaTime, Space.Self);
    }

    public void SetDefaultMoveSpeed()
    {
        _moveSpeed = _baseMoveSpeed;
    }

    public void ReturnBulletToPool()
    {
        StartCoroutine(ObjectPoolManager.ReturnObjectToPool(gameObject, _flyDistance / _moveSpeed * 1.1f));
    }
}
