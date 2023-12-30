using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ContinueButton : BaseButton
{
    [SerializeField] private Button _pauseButton;
    [SerializeField] private GameObject _pausePanel;

    protected override void OnClick()
    {
        Time.timeScale = 1;
        _pauseButton.transform.parent.gameObject.SetActive(true);
        _pausePanel.SetActive(false);
    }
}
