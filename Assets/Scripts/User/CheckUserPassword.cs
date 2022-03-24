using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
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
    private InputManager inputManager;
    private InputAction _uiInputs;

    public void Initialize()
    {
        instance = this;
        _getInputFields = GetComponent<GetInputFields>();
        passwordInput = _getInputFields._tmpInputFields[0];
        accessBtn.onClick.AddListener(() => { CheckInsertedPassword(); });
        returnBtn.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome); });

        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
        
        inputManager = InputManager.instance;
        _uiInputs = inputManager.userInputs.UIInputs.EnterKey;
        //inputManager.userInputs.UIInputs.EnterKey.performed += ctx => {CheckPassword(); };
    }

    public void EnableScript(bool enable)
    {
        switch (enable)
        {
            case true: _uiInputs.performed +=  CheckPw; 
                break;
            case false: _uiInputs.performed -=  CheckPw; 
                break;
        }
        
    }
    
    
    public void SetInfoToWork(int userId) {
        _id = userId;
        PersistentSaveManager.Instance.GetCurrentUserPosition(_id);
        CheckIfNeedPw();
    }

    private void CheckIfNeedPw() {
        var usingPw = psm.GetPasswordNeeded(_id);
        if (!usingPw) { gm.ChangeGameStateE(Enums.AppStates.PasswordCont); }
    }

    private void CheckInsertedPassword()
    {
        if (passwordInput.text.Trim() == psm.GetCurrentUserPassword(_id))
        {
            Debug.Log("password accepted");
            gm.ChangeGameStateE(Enums.AppStates.PasswordCont);
        }
        else
        {
            passwordInput.text = String.Empty;
            Debug.Log("Wrong Password");
        }
    }

    public void CheckPw(InputAction.CallbackContext context)
    {
        CheckInsertedPassword();
    }
    
    
}
