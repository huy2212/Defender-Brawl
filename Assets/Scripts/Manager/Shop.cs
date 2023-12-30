using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public static Shop Instance { get; private set; }
    [SerializeField] private Earning _earning;
    [SerializeField] private List<string> _itemNames;
    [SerializeField] private List<int> _itemCosts;
    [SerializeField] private List<Button> _itemButtons;
    [SerializeField] private List<string> _buyOnceItems;
    private Dictionary<string, int> _items;
    public event System.Action<string> OnPurchaseSuccess;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
            return;
        }

        if (_earning == null)
        {
            _earning = FindObjectOfType<Earning>();
        }
    }

    private void Start()
    {
        _items = new Dictionary<string, int>();
        for (int i = 0; i < _itemNames.Count && i < _itemCosts.Count; i++)
        {
            string itemName = _itemNames[i];
            _items.Add(itemName, _itemCosts[i]);
            _itemButtons[i].onClick.AddListener(() => PurchaseItem(itemName));
        }
        LoadBuyOnceItems();
    }

    private void PurchaseItem(string itemName)
    {
        int cost = _items[itemName];
        bool isEnoughGold = GoldManager.Instance.SubtractGold(cost);
        if (!isEnoughGold)
        {
            return;
        }
        OnPurchaseSuccess?.Invoke(itemName);
    }

    private void SetPurchasedState(string itemName)
    {
        int index = _itemNames.IndexOf(itemName);
        BuyOnceButton buyOnceButton = _itemButtons[index].GetComponent<BuyOnceButton>();
        if (buyOnceButton != null)
        {
            if (_earning.IsItemOwned(itemName))
            {
                buyOnceButton.SetPurchasedOnceButton(itemName);
            }
        }
    }

    private void LoadBuyOnceItems()
    {
        for (int i = 0; i < _buyOnceItems.Count; i++)
        {
            string itemName = _buyOnceItems[i];
            SetPurchasedState(itemName);
        }
    }
}