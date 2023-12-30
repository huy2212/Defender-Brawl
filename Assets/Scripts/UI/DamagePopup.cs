using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private float _disappearTime;
    [SerializeField] private float _disappearSpeed;
    [SerializeField] private float _flySpeed;
    private float _defaultDisappearTime;
    private TMP_Text _text;
    private Color _textColor;

    private void Awake()
    {
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void Start()
    {
        _textColor = _text.color;
        _defaultDisappearTime = _disappearTime;
    }

    private void LateUpdate()
    {
        transform.Translate(Vector3.up * _flySpeed * Time.deltaTime);
        _disappearTime -= Time.deltaTime;

        if (_disappearTime <= 0)
        {
            _textColor.a -= _disappearSpeed * Time.deltaTime;
            _text.color = _textColor;
            if (_textColor.a <= 0)
            {
                ObjectPoolManager.ReturnObjectToPool(this.gameObject);
                // Set back default values
                _disappearTime = _defaultDisappearTime;
                _textColor.a = 1f;
                _text.color = _textColor;
            }
        }
    }
}
