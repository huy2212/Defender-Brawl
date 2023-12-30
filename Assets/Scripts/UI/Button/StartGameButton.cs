using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButton : LoadSceneButton
{
    protected override void Start()
    {
        base.Start();
        string name = LoadManager.Instance.LoadName();
        if (name != "")
        {
            base._sceneIndex = 2;
        }
        else
        {
            base._sceneIndex = 1;
        }
    }
}
