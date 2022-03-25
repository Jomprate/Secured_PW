using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class SetPasswordInfoInCons : MonoBehaviour
{
    public static SetPasswordInfoInCons instance;
    
    private GetInputFields _getInputFields;
    public TextMeshProUGUI passwordIdTmp;
    public List<TMP_InputField> _tmpInputFields;


    private void Awake()
    {
        instance = this;
    }

    private void OnEnable() {
        if (_getInputFields == null) { _getInputFields = GetComponent<GetInputFields>(); }
        _tmpInputFields = _getInputFields.tmpInputFields;
    }

   

    public void SetPasswordInfo(int selected)
    {
        var DSM = DataSaveManager.instance;
        if (DSM.saveDataObject == null) return;
            passwordIdTmp.text = DSM.saveDataObject.PasswordDataL[selected].passwordId;
            _tmpInputFields[0].text = DSM.saveDataObject.PasswordDataL[selected].email;
            _tmpInputFields[1].text = DSM.saveDataObject.PasswordDataL[selected].userName;
            _tmpInputFields[2].text = DSM.saveDataObject.PasswordDataL[selected].password;
            _tmpInputFields[3].text = DSM.saveDataObject.PasswordDataL[selected].description;
    }

    public void ResetPasswordInfo()
    {
        passwordIdTmp.text = String.Empty;
        foreach (var tmpInputField in _tmpInputFields)
        {
            tmpInputField.text = String.Empty;
        }
    }

}
