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
    public List<TMP_InputField> tmpInputFields;


    private void Awake()
    {
        instance = this;
    }

    private void OnEnable() {
        if (_getInputFields == null) { _getInputFields = GetComponent<GetInputFields>(); }
        tmpInputFields = _getInputFields.tmpInputFields;
    }

    public void SetPasswordInfo(int selected)
    {
        var DSM = DataSaveManager.instance;
        if (DSM.saveDataObject == null) return;
            passwordIdTmp.text = DSM.saveDataObject.PasswordDataL[selected].passwordId;
            tmpInputFields[0].text = DSM.saveDataObject.PasswordDataL[selected].email;
            tmpInputFields[1].text = DSM.saveDataObject.PasswordDataL[selected].userName;
            tmpInputFields[2].text = DSM.saveDataObject.PasswordDataL[selected].password;
            tmpInputFields[3].text = DSM.saveDataObject.PasswordDataL[selected].description;
    }

    public void ResetPasswordInfo()
    {
        passwordIdTmp.text = string.Empty;
        foreach (var tmpInputField in tmpInputFields)
        {
            tmpInputField.text = string.Empty;
        }
    }

}
