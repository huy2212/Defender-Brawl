using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : BaseButton
{
    [SerializeField] private GameObject _pausePanel;
    private bool isPaused = false;

    protected override void Start()
    {
        base.Start();
        _pausePanel.SetActive(false);
    }

    protected override void OnClick()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0;
            this.transform.parent.gameObject.SetActive(false);
            _pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            this.transform.parent.gameObject.SetActive(true);
        }
    }
}
