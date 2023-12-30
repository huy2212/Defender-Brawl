using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : BaseButton
{
    protected override void OnClick()
    {
        LoadingManager.Instance.ReLoadScene();
    }
}
