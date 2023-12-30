using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtractGoldButton : BaseButton
{
    [SerializeField] private int _goldToSubtract;

    protected override void OnClick()
    {
        GoldManager.Instance.SubtractGold(_goldToSubtract);
    }
}
