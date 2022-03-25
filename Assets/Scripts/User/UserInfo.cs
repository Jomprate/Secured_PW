using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
[RequireComponent(typeof(BlinkRed))]
public class UserInfo : MonoBehaviour
{
    public static UserInfo instance;
    private BlinkRed _blinkRed;
    
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
        _blinkRed = GetComponent<BlinkRed>();
        
        _encryptImage = encryptBtn.image;
        _usePasswordImage = usePwBtn.image;
        
        ResetConsole();
        /*_encryptImage.color = redC;
        _usePasswordImage.color = redC;

        Encrypt = false;
        encrypt = false;
        UsePassword = false;
        usePassword = false;
        passwordTMP.interactable = false;*/
        
        
        encryptBtn.onClick.AddListener(() => { ChangeEncryptState();});
        usePwBtn.onClick.AddListener(() => { ChangeUsePasswordState();});
    }
    


    public void CheckNewUserData() {
        switch (UsePassword)
        {
            case true:
                if (UsIn_CheckTextLenght.CheckTextL(userNameTMP,3,_blinkRed) && UsIn_CheckTextLenght.CheckTextL(passwordTMP,3,_blinkRed)){
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
                if (UsIn_CheckTextLenght.CheckTextL(userNameTMP,3,_blinkRed)){
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
        _usePasswordImage.color = UsePassword ? greenC : redC;
        ActiveOrUnActivePw();
    }
    
    public void SetUserInfo() {
        UserName = userNameTMP.text;
        UserPassword = passwordTMP.text;
    }
    
    public void ResetConsole()
    {
        UserId = 0;
        UserAccessPath = null;
        UserEncrypt = false;
        UserName = string.Empty;
        UserPassword = string.Empty;
        Encrypt = false;
        encrypt = false;
        UsePassword = false;
        usePassword = false;
        passwordTMP.interactable = false;

        userNameTMP.text = string.Empty;
        passwordTMP.text = string.Empty;
        
        _encryptImage.color = redC;
        _usePasswordImage.color = redC;
    }
    
}
