using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayFX : BaseButton
{
    [SerializeField] private ParticleSystem _fxToPlay;
    [SerializeField] private TMP_Text _costText;

    private void OnEnable()
    {
        _costText = GetComponentInChildren<TMP_Text>();
        _fxToPlay = GetComponentInChildren<ParticleSystem>();
    }

    protected override void OnClick()
    {
        int cost = int.Parse(_costText.text);
        if (GoldManager.Instance.Gold >= cost)
        {
            Debug.Log("Play FX");
            _fxToPlay.Play();
        }
    }
}