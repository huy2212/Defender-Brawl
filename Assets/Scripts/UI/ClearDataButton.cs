using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearDataButton : BaseButton
{
    protected override void OnClick()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
