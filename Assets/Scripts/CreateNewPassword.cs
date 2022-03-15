using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateNewPassword : MonoBehaviour
{
    public static CreateNewPassword instance;
    
    public string passwordId { get; set; }
    public string email { get; set; }
    public string userName { get; set; }
    public string password { get; set; }
    public string description { get; set; }


    private GetInputFields _getInputFields;
    public List<TMP_InputField> _tmpInputFields;
    
    
    
    private void OnEnable()
    {
        instance = this;
        if (_getInputFields == null) { _getInputFields = GetComponent<GetInputFields>(); }
        _tmpInputFields = _getInputFields._tmpInputFields;
    }

    private void NewPasswordInfo()
    {
        passwordId = _tmpInputFields[0].text;
        email = _tmpInputFields[1].text;
        userName = _tmpInputFields[2].text;
        password = _tmpInputFields[3].text;
        description = _tmpInputFields[4].text;
        
        
            
    }

    public void ResetPasswordConsole()
    {
        passwordId = null;
        email = null;
        userName = null;
        password = null;
        description = null;

        foreach (var inputField in _tmpInputFields)
        {
            inputField.text = null;
        }
    }
    
}
