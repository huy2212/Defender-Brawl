using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEnergyButton : BaseButton
{
    [SerializeField] private int _energyToAdd;
    protected override void OnClick()
    {
        Shop.Instance.OnPurchaseSuccess += AddEnergy;
    }

    private void AddEnergy(string itemName)
    {
        EnergyManager.Instance.AddEnergy(_energyToAdd);
        Shop.Instance.OnPurchaseSuccess -= AddEnergy;
    }
}
