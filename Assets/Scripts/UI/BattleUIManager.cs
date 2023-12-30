using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Raise error when not enough coin
// Make coin turn red when not enough coin
// Make character button dim when there is not enough coin

public class BattleUIManager : MonoBehaviour
{
    [SerializeField] private GameObject _notEnoughCoinText;

    private void Start()
    {
    }

    private void OnEnable()
    {
        GameManager.Instance.OnNotEnoughCoin += ShowNotEnoughCoinText;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnNotEnoughCoin -= ShowNotEnoughCoinText;
    }

    private void ShowNotEnoughCoinText()
    {
        _notEnoughCoinText.transform.parent.gameObject.SetActive(true);
        _notEnoughCoinText.SetActive(true);
        Debug.Log("Not enough coin");
    }
}
