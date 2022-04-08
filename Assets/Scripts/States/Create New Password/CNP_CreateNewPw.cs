using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CNP_CreateNewPw : MonoBehaviour
{
    private CreateNewPassword _cnp;
    private List<TMP_InputField> _tmpInputFields;
    public void SetNeeded(CreateNewPassword createNewPassword, List<TMP_InputField> inputFields)
    {
        _cnp = createNewPassword;
        _tmpInputFields = inputFields;
    }
    
    public void CreateNewPw() {
        var dsm = DataSaveManager.instance;
        
        
        _cnp.PasswordId  = _tmpInputFields[0].text;
        _cnp.Email       = _tmpInputFields[1].text;
        _cnp.UserName    = _tmpInputFields[2].text;
        _cnp.Password    = _tmpInputFields[3].text;
        _cnp.Description = _tmpInputFields[4].text;
        
        dsm.CreateNewPasswordData();
        ResetPasswordConsole();
        GameManager.instance.PasswordContSec();
    }


    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void ResetPasswordConsole( )
    {
        _cnp.PasswordId = null;
        _cnp.Email = null;
        _cnp.UserName = null;
        _cnp.Password = null;
        _cnp.Description = null;

        foreach (var inputField in _tmpInputFields)
        {
            inputField.text = null;
        }
    }
}
