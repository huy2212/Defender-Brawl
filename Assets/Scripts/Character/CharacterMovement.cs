using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private SpeedData _speed;
    private IDetectable _iDetectable;
    private IDamageable _iDamageable;
    private bool _isFacingRight = true;
    private int _isLeftSpawned;
    private float _baseMoveSpeed;
    private float _moveSpeed;
    private bool _canMove;

    public float MoveSpeed
    {
        get => _moveSpeed;
        set => _moveSpeed = value;
    }
    public bool CanMove
    {
        get => _canMove;
        set => _canMove = value;
    }
    public bool IsFacingRight
    {
        get => _isFacingRight;
        set => _isFacingRight = value;
    }

    private void Awake()
    {
        _iDetectable = GetComponent<IDetectable>();
        _iDamageable = GetComponent<IDamageable>();
    }

    private void Start()
    {
        _isLeftSpawned = transform.rotation.y == 0f ? 1 : -1;
        _moveSpeed = _speed.MoveSpeed;
        _baseMoveSpeed = _moveSpeed;
    }

    private void OnEnable()
    {
        _canMove = true;
        _iDetectable.OnTargetDetected += StopMove;
        _iDetectable.OnTargetLost += StartMove;
        _iDamageable.OnDie += StopMove;
    }

    private void OnDisable()
    {
        _canMove = false;
        _iDetectable.OnTargetDetected -= StopMove;
        _iDetectable.OnTargetLost -= StartMove;
        _iDamageable.OnDie -= StopMove;
    }

    private void LateUpdate()
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

    private void StopMove()
    {
        if (_canMove == true)
        {
            _canMove = false;
        }
    }

    private void StartMove()
    {
        if (_canMove == false)
        {
            _canMove = true;
        }
    }
}
