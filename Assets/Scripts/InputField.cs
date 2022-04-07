using TMPro;
using UnityEngine;

public class InputField : MonoBehaviour,IInputField
{
    public Enums.InputFieldType _inputFieldType { get; set; }
    public TMP_InputField _inputField { get; set; }
    public Enums.InputFieldType inputFieldType;

    private void Awake()
    {
        _inputField = GetComponent<TMP_InputField>();
        _inputFieldType = inputFieldType;
    }
}
