using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CopyToClipboardBtn : MonoBehaviour
{
    public Button thisButton;

    public TMP_InputField inputField;
    private string textToCopy;

    private void OnEnable()
    {
        thisButton = GetComponent<Button>();
        inputField = transform.parent.GetComponent<TMP_InputField>();
        thisButton.onClick.AddListener(() => { copyToClipboard(inputField.text); });
    }

    private void copyToClipboard(string text)
    {
        ClipboardExtension.CopyToClipboard(text);
        
    }
    
}
