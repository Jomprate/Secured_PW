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
        CheckUser,
        PasswordCont,
        StartGame
    }
    
    public enum PanelType
    {
        WelcomeCanvas,
        CreateNewUser,
        SelectEnKeys,
        CheckUserPassword,
        PasswordContainer,
        CreateNewPassword,
        
        
    }
    
    public enum InputFieldType
    {
        UserInfo,
        Keys,
        PasswordData,
        Password
    }
}
