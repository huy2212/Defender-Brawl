using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Start()
    {
        _image.fillAmount = 0;
    }

    public IEnumerator StartCoolDown(float coolDownTime)
    {
        float time = 0;
        _image.fillAmount = 1;
        while (time < coolDownTime)
        {
            time += Time.deltaTime;
            _image.fillAmount = 1 - time / coolDownTime;
            yield return null;
        }
    }
}
