using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoldButton : BaseButton
{
    [SerializeField] private int _goldAmount;

    protected override void OnClick()
    {
        GoldManager.Instance.SubtractGold(0);
        GoldManager.Instance.AddGold(_goldAmount);
    }
}
