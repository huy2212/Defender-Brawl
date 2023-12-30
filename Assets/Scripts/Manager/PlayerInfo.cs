using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private Slider _starSlider;
    private int _star;

    private void OnEnable()
    {
        _star = LoadManager.Instance.LoadStars();
        _starSlider.value = (float)_star / 10;
    }
}
