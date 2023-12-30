using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FloatingText : MonoBehaviour
{
    [SerializeField] private float _fadeinTime;
    [SerializeField] private float _fadeoutTime;
    [SerializeField] private float _moveSpeed;
    private TMP_Text _text;
    private Vector3 _defaultPosition;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _defaultPosition = transform.position;
    }

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
        transform.position = _defaultPosition;
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
        this.gameObject.SetActive(false);
    }
}
