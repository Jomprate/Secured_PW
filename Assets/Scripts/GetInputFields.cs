using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetInputFields : MonoBehaviour
{
    public List<TMP_InputField> _tmpInputFields;
    public Enums.InputFieldType iType;

    public List<TMP_InputField> GetFields() {
        var inputFields = GetComponentsInChildren<IInputField>();
        Debug.Log(inputFields);
        foreach (var inputField in inputFields) { _tmpInputFields.Add(inputField._inputField); }
        return (_tmpInputFields);
    }
    
    public List<TMP_InputField> GetFieldsW() {
        var inputFields = GetComponentsInChildren<IInputField>();
        foreach (var inputField in inputFields)
        {
            if (inputField._inputFieldType == iType)
            {
                _tmpInputFields.Add(inputField._inputField);
            }
            
        }
        
        return (_tmpInputFields);
    }
    
}
