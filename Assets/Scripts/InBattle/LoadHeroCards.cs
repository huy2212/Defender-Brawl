using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHeroCards : MonoBehaviour
{
    [SerializeField] private List<string> _heroNames;
    [SerializeField] private List<GameObject> _heroCards;

    private void Awake()
    {
        LoadOwnedHeroes();
    }

    private void LoadOwnedHeroes()
    {
        List<string> ownedItems = LoadManager.Instance.LoadOwnedItems();
        foreach (string heroName in ownedItems)
        {
            if (_heroNames.Contains(heroName))
            {
                int index = _heroNames.IndexOf(heroName);
                _heroCards[index].SetActive(true);
            }
        }
    }
}
