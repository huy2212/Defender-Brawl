using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPanelOffButton : BaseButton
{
    [SerializeField] private GameObject _panel;

    protected override void OnClick()
    {
        _panel.SetActive(false);
    }
}
