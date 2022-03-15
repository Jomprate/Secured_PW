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
        _tmpInputFields = _getInputFields._tmpInputFields;
    }

    public void SetPasswordInfo(int selected) {
        if (DataSaveManager.instance.saveDataObject == null) return;
            passwordIdTmp.text = DataSaveManager.instance.saveDataObject.PasswordDataL[selected].passwordId;
            _tmpInputFields[0].text = DataSaveManager.instance.saveDataObject.PasswordDataL[selected].email;
            _tmpInputFields[1].text = DataSaveManager.instance.saveDataObject.PasswordDataL[selected].userName;
            _tmpInputFields[2].text = DataSaveManager.instance.saveDataObject.PasswordDataL[selected].password;
            _tmpInputFields[3].text = DataSaveManager.instance.saveDataObject.PasswordDataL[selected].description;
    }

}
