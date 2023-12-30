using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanelButton : BaseButton
{
    [SerializeField] private GameObject _needToHidePanel;
    [SerializeField] private GameObject _needToShowPanel;

    protected override void OnClick()
    {
        this.SwitchPanelHandler();
    }

    private void SwitchPanelHandler()
    {
        _needToHidePanel.SetActive(false);
        _needToShowPanel.SetActive(true);
    }
}
