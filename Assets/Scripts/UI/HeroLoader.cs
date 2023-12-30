using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HeroLoader : MonoBehaviour
{
    [SerializeField] private UpgradeProcessor _upgradeProcessor;
    [SerializeField] private List<string> _heroNames;
    [SerializeField] private List<GameObject> _heroCards;
    [SerializeField] private List<TMP_Text> _coinText;
    [SerializeField] private List<TMP_Text> _levelText;
    [SerializeField] private List<AttackData> _heroData;
    [SerializeField] private List<TMP_Text> _currentStats;
    [SerializeField] private List<TMP_Text> _nextStats;
    [SerializeField] private List<Button> _upgradeButtons;
    public event System.Action OnUpgradeSuccess;


    private void OnEnable()
    {
        LoadHeroes();
        LoadUpgradeCost();
        AddListeners();
    }

    private void AddListeners()
    {
        for (int i = 0; i < _upgradeButtons.Count; i++)
        {
            // Remove all listeners from the button
            _upgradeButtons[i].onClick.RemoveAllListeners();

            int index = i;
            _upgradeButtons[i].onClick.AddListener(() => Upgrade(index));
        }
    }

    private void LoadHeroes()
    {
        List<string> ownedItem = LoadManager.Instance.LoadOwnedItems();
        for (int i = 0; i < _heroNames.Count; i++)
        {
            if (ownedItem.Contains(_heroNames[i]))
            {
                _heroCards[i].SetActive(true);
            }
        }
    }

    private void LoadUpgradeCost()
    {
        for (int i = 0; i < _heroNames.Count; i++)
        {
            if (_heroNames[i] != _upgradeProcessor.UpgradeItems[i].ItemName)
            {
                Debug.LogError("Wrong name and item upgrade order!");
                return;
            }
            int currentLevel = _upgradeProcessor.UpgradeItems[i].CurrentLevel;
            int upgradeCost = _upgradeProcessor.UpgradeItems[i].ItemInfos[currentLevel - 1].UpgradeCost;
            _coinText[i].text = upgradeCost.ToString();
            if (_coinText[i].text == "9999")
            {
                _upgradeButtons[i].interactable = false;
            }
            _levelText[i].text = "Level " + currentLevel.ToString();
            _currentStats[i].text = _heroData[i].Damage.ToString();
            _nextStats[i].text = (_heroData[i].Damage + _upgradeProcessor.UpgradeItems[i].ItemInfos[currentLevel - 1].UpgradeDamage).ToString();
        }
    }

    public void Upgrade(int index)
    {
        int itemCost = _upgradeProcessor.UpgradeItems[index].ItemInfos[_upgradeProcessor.UpgradeItems[index].CurrentLevel - 1].UpgradeCost;
        bool isUpgradeSuccess = GoldManager.Instance.SubtractGold(itemCost);
        if (isUpgradeSuccess)
        {
            ChangeHeroDataOnUpgrade(index);
            OnUpgradeSuccess?.Invoke();
        }
    }

    private void ChangeHeroDataOnUpgrade(int index)
    {
        int currentLevel = _upgradeProcessor.UpgradeItems[index].CurrentLevel;
        int maxLevel = _upgradeProcessor.UpgradeItems[index].MaxLevel;
        currentLevel++;
        _upgradeProcessor.UpgradeItems[index].CurrentLevel = currentLevel;
        if (currentLevel <= maxLevel)
        {
            if (currentLevel == maxLevel)
            {
                _upgradeButtons[index].interactable = false;
            }
            int cost = _upgradeProcessor.UpgradeItems[index].ItemInfos[currentLevel - 1].UpgradeCost;
            _coinText[index].text = cost.ToString();
            _levelText[index].text = "Level " + currentLevel.ToString();
            _heroData[index].Damage += _upgradeProcessor.UpgradeItems[index].ItemInfos[currentLevel - 1].UpgradeDamage;
            _currentStats[index].text = _heroData[index].Damage.ToString();
            _nextStats[index].text = (_heroData[index].Damage + _upgradeProcessor.UpgradeItems[index].ItemInfos[currentLevel - 1].UpgradeDamage).ToString();
        }
    }
}
