using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum AppStates
    {
    
        Initialization,
        Welcome,
        MainMenu,
        CreateNewUser,
        PasswordCont,
        StartGame
    }
    
    public enum PanelType
    {
        WelcomeCanvas,
        CreateNewUser,
        SelectEnKeys,
        CheckUserInfo,
        PasswordContainer,
        CreateNewPassword
        
    }
    
    public enum InputFieldType
    {
        UserInfo,
        Keys,
        passwordData
    }
}
