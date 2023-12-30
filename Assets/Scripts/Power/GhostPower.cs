using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPower : ShootingPower
{
    [SerializeField] private int _audioIndex;

    protected override void UsePower()
    {
        SoundManager.Instance.PlayOneShotWithTime((SoundType)_audioIndex, 4.5f);
        base.UsePower();
    }
}
