using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameInputHandler : MonoBehaviour
{
    private const int MAX_NAME_LENGTH = 10;
    [SerializeField] private TMP_InputField _nameInputField;
    [SerializeField] private Button _OKButton;
    [SerializeField] private TMP_Text _errorText;

    private void Start()
    {
        // set interaction of okbutton to false
        _OKButton.interactable = false;
        _nameInputField.onValueChanged.AddListener(ValidateName);
        _nameInputField.characterLimit = MAX_NAME_LENGTH;
    }

    public void ValidateName(string input)
    {
        string playerName = input;

        playerName = playerName.Trim();

        if (playerName.Contains(" "))
        {
            _errorText.text = "Name cannot contain spaces";
            _OKButton.interactable = false;
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(playerName, "^[a-zA-Z0-9]+$"))
        {
            _errorText.text = "Name cannot contain special characters";
            _OKButton.interactable = false;
            return;
        }
        _errorText.text = "";
        _OKButton.interactable = true;
    }
}
