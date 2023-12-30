using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour, ITurnable
{
    private Quaternion _defaultRotation;
    private IDetectable _iDetectable;
    private IDamageable _iDamageable;
    private bool _isForward = true;
    private bool _canTurn;
    private Canvas _canvas;
    private Quaternion _defaultCanvasRotation;
    public bool CanTurn { get => _canTurn; set => _canTurn = value; }

    private void Awake()
    {
        _iDetectable = GetComponent<IDetectable>();
        _iDamageable = GetComponent<IDamageable>();
        _canvas = GetComponentInChildren<Canvas>();
    }

    private void OnEnable()
    {
        _canTurn = true;
        _iDamageable.OnDie += StopTurn;
    }

    private void OnDisable()
    {
        _canTurn = false;
        _iDamageable.OnDie -= StopTurn;
    }

    private void Start()
    {
        _defaultCanvasRotation = _canvas.transform.rotation;
        _defaultRotation = transform.rotation;
    }

    private void LateUpdate()
    {
        GameObject target = _iDetectable.Target;
        if (target != null)
        {
            Vector2 targetDirection = target.transform.position - transform.position;
            float dot = 0f;
            if (_isForward)
            {
                dot = Vector3.Dot(targetDirection, new Vector2(transform.right.x, transform.right.y));
            }
            else
            {
                dot = Vector3.Dot(targetDirection, new Vector2(-transform.right.x, -transform.right.y));
            }
            if (dot < 0f)
            {
                TurnBackward();
            }
            else if (!_isForward)
            {
                TurnForward();
            }
        }
        else if (!_isForward)
        {
            TurnForward();
        }
    }

    public void TurnBackward()
    {
        if (_canTurn)
        {
            _isForward = false;
            transform.rotation = _defaultRotation * Quaternion.Euler(0f, 180f, 0f);
            _canvas.transform.rotation = _defaultCanvasRotation;
        }
    }

    public void TurnForward()
    {
        if (_canTurn)
        {
            _isForward = true;
            transform.rotation = _defaultRotation;
            _canvas.transform.rotation = _defaultCanvasRotation;
        }
    }

    private void StopTurn()
    {
        _canTurn = false;
    }
}
