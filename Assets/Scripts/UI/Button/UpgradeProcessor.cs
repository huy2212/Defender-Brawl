using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeData", menuName = "Data/Upgrade")]
public class UpgradeProcessor : ScriptableObject
{
    public UpgradeItems[] UpgradeItems;
}

[System.Serializable]
public class UpgradeItems
{
    public String ItemName;
    public int CurrentLevel;
    public int MaxLevel;
    public ItemInfo[] ItemInfos;
}

[System.Serializable]
public class ItemInfo
{
    public int UpgradeCost;
    public float UpgradeDamage;
    public float UpgradeAttackDelay;
    public float UpgradeSpeed;
}

