using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public interface IInputField
{
    Enums.InputFieldType _inputFieldType { get; set; }
    TMP_InputField _inputField { get; set; }
}
