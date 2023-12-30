using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrayFighterPower : DamageMultiplierPower
{
    [SerializeField] private int _audioIndex;

    protected override void UsePower()
    {
        SoundManager.Instance.OnPlaySound((SoundType)_audioIndex);
        base.UsePower();
    }
}
