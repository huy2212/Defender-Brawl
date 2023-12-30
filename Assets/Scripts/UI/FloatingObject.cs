using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingObject : MonoBehaviour
{
    [SerializeField] private float _fadeinTime;
    [SerializeField] private float _fadeoutTime;
    [SerializeField] private float _moveSpeed;
    private Color _color;

    private void Awake()
    {
        TMP_Text _text = GetComponent<TMP_Text>();
        if (_text != null)
            _color = _text.color;
        else
            _color = GetComponent<SpriteRenderer>().color;
        _color = GetComponent<TMP_Text>().color;
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    private void Update()
    {
        transform.position += Vector3.up * _moveSpeed * Time.deltaTime;
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0;
        Color color = _text.color;
        while (elapsedTime < _fadeinTime)
        {
            color.a = Mathf.Lerp(0, 1, elapsedTime / _fadeinTime);
            _text.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0;
        Color color = _text.color;
        while (elapsedTime < _fadeoutTime)
        {
            color.a = Mathf.Lerp(1, 0, elapsedTime / _fadeoutTime);
            _text.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        ObjectPoolManager.ReturnObjectToPool(this.gameObject);
    }
}
