using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : BaseButton
{
    protected override void OnClick()
    {
        LoadingManager.Instance.LoadScene(2);
    }
}
