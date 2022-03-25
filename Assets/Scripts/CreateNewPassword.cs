using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CreateNewPassword : MonoBehaviour
{
    public static CreateNewPassword instance;

    [SerializeField] private Button CreateNewPw_Btn;
    
    public string PasswordId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }


    private GetInputFields _getInputFields;
    public List<TMP_InputField> _tmpInputFields;

    public void Initialize()
    {
        instance = this;
        
        if (_getInputFields == null) { _getInputFields = GetComponent<GetInputFields>(); }
        
        _tmpInputFields = _getInputFields.tmpInputFields;
        
        CreateNewPw_Btn.onClick.AddListener(() => { CreateNewPw(); });
    }
   

    private void CreateNewPw() {
        var dsm = DataSaveManager.instance;
            PasswordId  = _tmpInputFields[0].text;
            Email       = _tmpInputFields[1].text;
            UserName    = _tmpInputFields[2].text;
            Password    = _tmpInputFields[3].text;
            Description = _tmpInputFields[4].text;
        dsm.CreateNewPasswordData();
        ResetPasswordConsole();
        GameManager.instance.PasswordContSec();
    }
    
    

    public void ResetPasswordConsole()
    {
        PasswordId = null;
        Email = null;
        UserName = null;
        Password = null;
        Description = null;

        foreach (var inputField in _tmpInputFields)
        {
            inputField.text = null;
        }
    }
    
}
