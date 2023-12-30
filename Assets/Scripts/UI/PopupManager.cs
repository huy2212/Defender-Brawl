using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum PopupType
{
    DamagePopup = 0,
    CriticalPopup = 1,
    HealPopup = 2,
    None
}
public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }
    [SerializeField] private GameObject _damagePopupPrefab;
    [SerializeField] private GameObject _criticalPopupPrefab;
    [SerializeField] private GameObject _healPopupPrefab;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if (_damagePopupPrefab == null)
        {
            _damagePopupPrefab = Resources.Load<GameObject>("Prefabs/Popup/DamagePopup");
        }
        if (_criticalPopupPrefab == null)
        {
            _criticalPopupPrefab = Resources.Load<GameObject>("Prefabs/UI/CriticalPopup");
        }
    }

    public void ShowDamagePopup(float amount, PopupType popupType, Vector3 position)
    {
        switch (popupType)
        {
            case PopupType.DamagePopup:
                var damagePopup = ObjectPoolManager.SpawnObject(_damagePopupPrefab, position, Quaternion.identity, ObjectPoolManager.PoolType.GameObject).GetComponentInChildren<TMP_Text>();
                damagePopup.SetText(amount.ToString());
                break;
            case PopupType.CriticalPopup:
                var criticalPopup = ObjectPoolManager.SpawnObject(_criticalPopupPrefab, position, Quaternion.identity, ObjectPoolManager.PoolType.GameObject).GetComponentInChildren<TMP_Text>();
                criticalPopup.SetText(amount.ToString());
                break;
            case PopupType.HealPopup:
                var healPopup = ObjectPoolManager.SpawnObject(_healPopupPrefab, position, Quaternion.identity, ObjectPoolManager.PoolType.GameObject).GetComponentInChildren<TMP_Text>();
                healPopup.SetText(amount.ToString());
                break;
        }
    }
}
