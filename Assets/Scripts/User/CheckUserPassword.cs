using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckUserPassword : MonoBehaviour
{
    public static CheckUserPassword instance;
    
    private GetInputFields _getInputFields;

    private PersistentSaveManager psm;
    private GameManager gm;
    
    [SerializeField] private TMP_InputField passwordInput;
    [SerializeField] private Button accessBtn;
    [SerializeField] private Button returnBtn;


    private int _id;

    public void Initialize()
    {
        instance = this;
        _getInputFields = GetComponent<GetInputFields>();
        passwordInput = _getInputFields._tmpInputFields[0];
        accessBtn.onClick.AddListener(() => { CheckPassword(); });
        returnBtn.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome); });
        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
    }

    public void SetInfoToWork(int userId) {
        _id = userId;
        CheckIfNeedPw();
    }

    private void CheckIfNeedPw() {
        var usingPw = psm.GetPasswordNeeded(_id);
        if (!usingPw) { gm.ChangeGameStateE(Enums.AppStates.PasswordCont); }
    }

    private void CheckPassword()
    {
        if (passwordInput.text.Trim() == psm.GetCurrentUserPassword(_id))
        {
            Debug.Log("password accepted");
            gm.ChangeGameStateE(Enums.AppStates.PasswordCont);
        }
        else
        {
            Debug.Log("Wrong Password");
        }
    }
   
    
    
}
