using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MonoBehaviour, IDetectable
{
    [SerializeField] private AttackData _attackData;
    private Animator _animator;
    private IDamageable _iDamageable;
    private float _range;
    private bool _canDetect;
    private GameObject _target = null;
    private LayerMask _targetLayer;
    public float Range
    {
        get => _range;
        set => _range = value;
    }
    public LayerMask TargetLayer
    {
        get => _targetLayer;
        set => _targetLayer = value;
    }
    public GameObject Target => _target;

    public bool CanDetect { get => _canDetect; set => _canDetect = value; }
    public event System.Action OnTargetDetected;
    public event System.Action OnTargetLost;

    private void Awake()
    {
        _iDamageable = GetComponent<IDamageable>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _canDetect = true;
        _iDamageable.OnDie += StopDetection;
    }

    private void OnDisable()
    {
        _canDetect = false;
        _iDamageable.OnDie -= StopDetection;
    }

    private void Start()
    {
        _range = _attackData.Range;
        _targetLayer = _attackData.TargetLayer;
    }

    private void LateUpdate()
    {
        DetectTargets();
    }

    public void DetectTargets()
    {
        if (_canDetect)
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, _range, _targetLayer);
            if (hit != null)
            {
                _target = hit.gameObject;
                OnTargetDetected?.Invoke();
                _animator.SetBool("isIdle", true);
            }
            else
            {
                _target = null;
                OnTargetLost?.Invoke();
                _animator.SetBool("isIdle", false);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    private void StopDetection()
    {
        _canDetect = false;
    }
}
