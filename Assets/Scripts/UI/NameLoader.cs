using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NameLoader : MonoBehaviour
{
    [SerializeField] private TMP_Text _nameText;

    private void Start()
    {
        LoadName();
    }

    private void LoadName()
    {
        _nameText.text = LoadManager.Instance.LoadName();
    }
}
