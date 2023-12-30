using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earning : MonoBehaviour
{
    private List<string> _ownedItems;

    private void Awake()
    {
        LoadOwnedItems();
        if (_ownedItems.Count == 0)
        {
            _ownedItems.Add("GrayFighter");
        }
        SaveOwnedItems();
    }

    private void OnEnable()
    {
        Shop.Instance.OnPurchaseSuccess += OwnItem;
    }

    private void OnDisable()
    {
        Shop.Instance.OnPurchaseSuccess -= OwnItem;
    }

    private void OwnItem(string itemName)
    {
        if (_ownedItems.Contains(itemName))
        {
            return;
        }
        _ownedItems.Add(itemName);
        SaveOwnedItems();
    }

    private void LoadOwnedItems()
    {
        _ownedItems = LoadManager.Instance.LoadOwnedItems();
    }

    private void SaveOwnedItems()
    {
        SaveManager.Instance.SaveOwnedItems(_ownedItems);
    }

    public bool IsItemOwned(string itemName)
    {
        return _ownedItems.Contains(itemName);
    }
}
