using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SaveNameButton : BaseButton
{
    [SerializeField] private TMP_Text _text;

    protected override void OnClick()
    {
        this.SaveName();
    }

    public void SaveName()
    {
        string name = _text.text.Trim();
        SaveManager.Instance.SaveName(name);
        Debug.Log("Name saved: " + PlayerPrefs.GetString("PlayerName"));
    }
}
