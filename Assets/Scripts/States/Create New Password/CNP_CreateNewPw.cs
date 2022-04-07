using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CNP_CreateNewPw : MonoBehaviour
{
    public void CreateNewPw(CreateNewPassword cnp ,IReadOnlyList<TMP_InputField> tmpInputFields) {
        var dsm = DataSaveManager.instance;
        
        
        cnp.PasswordId  = tmpInputFields[0].text;
        cnp.Email       = tmpInputFields[1].text;
        cnp.UserName    = tmpInputFields[2].text;
        cnp.Password    = tmpInputFields[3].text;
        cnp.Description = tmpInputFields[4].text;
        
        dsm.CreateNewPasswordData();
        ResetPasswordConsole(cnp,tmpInputFields);
        GameManager.instance.PasswordContSec();
    }


    // ReSharper disable once MemberCanBeMadeStatic.Local
    private void ResetPasswordConsole(CreateNewPassword cnp, IEnumerable<TMP_InputField> tmpInputFields )
    {
        cnp.PasswordId = null;
        cnp.Email = null;
        cnp.UserName = null;
        cnp.Password = null;
        cnp.Description = null;

        foreach (var inputField in tmpInputFields)
        {
            inputField.text = null;
        }
    }
}
