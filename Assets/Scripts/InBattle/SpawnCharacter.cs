using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnCharacter : MonoBehaviour, ISpawnable
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private CharacterInGameStats _characterInGameStats;
    [SerializeField] private Transform _spawnPoint;
    private bool _isSucceedSpawn;
    private CoolDown _coolDown;
    private GameObject _spawnedObject;
    public GameObject SpawnedObject { get => _spawnedObject; set => _spawnedObject = value; }
    public float CoolDownTime { get => _coolDownTime; set => _coolDownTime = value; }
    public bool IsSucceedSpawn { get => _isSucceedSpawn; set => _isSucceedSpawn = value; }

    private float _price;
    private float _coolDownTime;

    private void Awake()
    {
        _price = _characterInGameStats.Price;
        _coolDownTime = _characterInGameStats.CoolDownTime;
        _coolDown = GetComponentInChildren<CoolDown>();
    }

    private void Start()
    {
        SetPrice();
    }

    public void Spawn()
    {
        if (GameManager.Instance.Coin < _price)
        {
            GameManager.Instance.InvokeOnNotEnoughCoin();
            _isSucceedSpawn = false;
            return;
        }
        _spawnedObject = Instantiate(_characterPrefab, _spawnPoint.position, _spawnPoint.rotation);
        StartCoolDown();
        GameManager.Instance.SubtractCoin(_price);
        _isSucceedSpawn = true;
    }

    private void StartCoolDown()
    {
        CoroutineManager.Instance?.StartCoroutine(_coolDown.StartCoolDown(_coolDownTime));
    }

    private void SetPrice()
    {
        Transform priceTransform = transform.Find("Price");
        if (priceTransform != null)
        {
            priceTransform.GetComponentInChildren<TMP_Text>().text = _price.ToString();
        }
    }
}
