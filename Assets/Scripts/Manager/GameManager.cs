using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Transform _heroBase;
    [SerializeField] private Transform _enemyBase;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private float _coinIncrement;
    [SerializeField] private float _timeBetWeenCoinIncrement;
    [SerializeField] private float _startCoin;
    private float _coin = 0;
    public float Coin { get => _coin; set => _coin = value; }
    public float CoinIncrement { get => _coinIncrement; set => _coinIncrement = value; }
    public event Action OnVictory;
    public event Action OnDefeat;
    public event Action OnNotEnoughCoin;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        _heroBase.GetComponent<Target>().OnDie += Defeated;
        _enemyBase.GetComponent<Target>().OnDie += Victory;
    }

    private void Start()
    {
        SubtractCoin(-_startCoin);
        CoroutineManager.Instance.StartCoroutine(AddCoin());
    }

    public void Defeated()
    {
        OnDefeat?.Invoke();
    }

    public void Victory()
    {
        OnVictory?.Invoke();
    }

    public IEnumerator AddCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(_timeBetWeenCoinIncrement);
            _coin += _coinIncrement;
            _coinText.text = _coin.ToString();
        }
    }

    public void SubtractCoin(float amount)
    {
        _coin -= amount;
        _coinText.text = _coin.ToString();
    }

    public void InvokeOnNotEnoughCoin()
    {
        OnNotEnoughCoin?.Invoke();
    }
}
