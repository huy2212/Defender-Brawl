using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSceneButton : BaseButton
{
    [SerializeField] protected int _sceneIndex;

    protected override void OnClick()
    {
        LoadingManager.Instance.LoadScene(_sceneIndex);
    }
}
