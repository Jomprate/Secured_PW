using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class InputField : MonoBehaviour,IInputField
{
    public Enums.InputFieldType _inputFieldType { get; set; }
    public TMP_InputField _inputField { get; set; }
    public Enums.InputFieldType InputFieldType;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputFieldType = InputFieldType;
    }
    
}
