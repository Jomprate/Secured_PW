using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(UICheckTextLenght))]
public class UserInfo : MonoBehaviour
{
    public static UserInfo instance;
    private UICheckTextLenght _uiCtLenght;
    
    public int UserId { get; set; }
    public string UserAccessPath { get; set; }
    public bool UserEncrypt { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set ; }
    public bool Encrypt { get; set; }
    public bool encrypt;
    public bool UsePassword { get; set; }
    public bool usePassword;
    public bool UserAccepted { get; set; }

    [SerializeField] private TMP_InputField userNameTMP;
    [SerializeField] private TMP_InputField passwordTMP;
    [SerializeField] private Button encryptBtn;
    [SerializeField] private Button usePwBtn;
    private Image _encryptImage;
    private Image _usePasswordImage;
    
    
    
    Color redC = Color.red;
    Color greenC = Color.green;


    public void Initialize()
    {
        instance = this;

        _uiCtLenght = GetComponent<UICheckTextLenght>();
        
        _encryptImage = encryptBtn.image;
        _usePasswordImage = usePwBtn.image;
        
        _encryptImage.color = redC;
        _usePasswordImage.color = redC;

        Encrypt = false;
        encrypt = false;
        UsePassword = false;
        usePassword = false;
        passwordTMP.interactable = false;
        
        
        encryptBtn.onClick.AddListener(() => { ChangeEncryptState();});
        usePwBtn.onClick.AddListener(() => { ChangeUsePasswordState();});
    }


    public void CheckNewUserData() {
        switch (UsePassword)
        {
            case true:
                if (_uiCtLenght.CheckTextL(userNameTMP,3) && _uiCtLenght.CheckTextL(passwordTMP,3)){
                    UserAccepted = true;
                    SetUserInfo();
                }
                else
                {
                    UserAccepted = false;
                    Debug.Log("to short");
                    //show something
                }
                break;
                
            case false:
                if (_uiCtLenght.CheckTextL(userNameTMP,3)){
                    UserAccepted = true;
                    SetUserInfo();
                }
                else
                {
                    UserAccepted = false;
                    Debug.Log("to short");
                    //show something
                }
                break;
        }
    }
    
    public void ActiveOrUnActivePw() {
        passwordTMP.interactable = usePassword;
        if (passwordTMP.interactable == false)
        {
            passwordTMP.text = String.Empty;
        }
    }
    
    public void ChangeEncryptState()
    {
        Encrypt = !Encrypt;
        encrypt = Encrypt;
        
        _encryptImage.color = Encrypt ? greenC : redC;
    }
    
    public void ChangeUsePasswordState()
    {
        UsePassword = !UsePassword;
        usePassword = UsePassword;
        //ActiveOrUnActivePw();
        _usePasswordImage.color = UsePassword ? greenC : redC;
        ActiveOrUnActivePw();
    }
    
    public void SetUserInfo() {
        UserName = userNameTMP.text;
        UserPassword = passwordTMP.text;
    }
    
}
