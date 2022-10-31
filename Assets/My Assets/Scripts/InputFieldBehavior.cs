using UnityEngine;
using TMPro;
using System;

//This script you attach to gameobject where is TMPro input field component.
public class InputFieldBehavior : MonoBehaviour
{
    TMP_InputField inputField;

    private void Start()
    {
        inputField = GetComponent<TMP_InputField>();
        inputField.contentType = TMP_InputField.ContentType.Alphanumeric;
        inputField.onEndEdit.AddListener(delegate
        {
            Int32.TryParse(inputField.text, out int value);
            ValidateInput(value);
        });
    }
    void ValidateInput(int value)
    {
        int maxValue = 10;
        int minValue = 1;

        if (value > maxValue)
        {
            inputField.text = maxValue.ToString();
        }
        else if (value <= minValue)
        {
            inputField.text = minValue.ToString();
        }
    }
}