using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetInputFields : MonoBehaviour
{
    public List<TMP_InputField> tmpInputFields;
    public Enums.InputFieldType iType;

    public List<TMP_InputField> GetFieldsW() {
        var inputFields = GetComponentsInChildren<IInputField>();
        foreach (var inputField in inputFields)
        {
            if (inputField._inputFieldType == iType)
            {
                tmpInputFields.Add(inputField._inputField);
            }
            
        }
        
        return tmpInputFields;
    }
    
}
