using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    [SerializeField] private float _spinSpeed;
    private IAttackable _observer;
    private bool isSpinning = false;

    private void Awake()
    {
        _observer = GetComponent<IAttackable>();
    }

    private void OnDisable()
    {
        StopSpinning();
    }
    private void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.forward * _spinSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = this.gameObject.tag;
        if (!collision.gameObject.CompareTag(tag))
        {
            StartSpinning();
        }
    }

    private void StartSpinning()
    {
        isSpinning = true;
    }

    private void StopSpinning()
    {
        isSpinning = false;
    }
}
