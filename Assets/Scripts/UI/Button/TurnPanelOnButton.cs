using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPanelOnButton : BaseButton
{
    [SerializeField] private GameObject _panel;

    protected override void OnClick()
    {
        _panel.SetActive(true);
    }
}
