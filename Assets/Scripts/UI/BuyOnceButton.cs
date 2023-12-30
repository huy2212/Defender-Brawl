using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOnceButton : BaseButton
{
    [SerializeField] private Earning _earning;
    [SerializeField] private GameObject _purchasedImage;
    [SerializeField] private string _itemName;

    protected virtual void OnEnable()
    {
        SetPurchasedOnceButton(_itemName);
        Shop.Instance.OnPurchaseSuccess += SetPurchasedOnceButton;
    }

    protected override void OnClick()
    {

    }

    public void SetPurchasedOnceButton(string itemName)
    {
        itemName = _itemName;
        _earning = FindObjectOfType<Earning>();
        bool isItemOwned = _earning.IsItemOwned(itemName);
        if (isItemOwned)
        {
            _purchasedImage.SetActive(true);
            this.button.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Shop.Instance.OnPurchaseSuccess -= SetPurchasedOnceButton;
    }
}
