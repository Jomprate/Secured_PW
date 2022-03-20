using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserInfo : MonoBehaviour
{
    public static UserInfo instance;
    
    public int UserId { get; set; }
    
    public string userAccessPath { get; set; }
    public bool userEncrypt { get; set; }
    public string UserName { get; set; }
    public string UserPassword { get; set; }
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
        Encrypt = false;
        UsePassword = true;
        _encryptImage = encryptBtn.image;
        _usePasswordImage = usePwBtn.image;
        
        _encryptImage.color = redC;
        _usePasswordImage.color = redC;
        
        encryptBtn.onClick.AddListener(() => { ChangeEncryptState();});
        usePwBtn.onClick.AddListener(() => { ChangeUsePasswordState();});
    }
    
    
    private void Awake()
    {
        instance = this;
        Encrypt = false;
        
        
    }


    public void CheckNewUserInfo() {
        if (userNameTMP.text.Trim().Length > 3 && passwordTMP.text.Trim().Length > 3)
        {
            UserAccepted = true;
            SetUserInfo();
        }
        else
        {
            UserAccepted = false;
            Debug.Log("to short");
            //show something
        }
        
        /*SetUserInfo();*/
        
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
    }
    
    
    public void SetUserInfo() {
        //UserId = 
        UserName = userNameTMP.text;
        UserPassword = passwordTMP.text;
        
        //PersistentSaveManager.instance.CreateNewUserWithoutEnData();
        //DataSaveManager.instance.CreateNewUser();
        //DataSaveManager.instance.SaveUsers();
    }
    
}
