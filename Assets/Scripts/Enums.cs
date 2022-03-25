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
        CreateNewPw,
        AdvicePw,
        StartGame
    }
    
    public enum PanelType
    {
        WelcomeCanvas,
        CreateNewUser,
        CheckUserPassword,
        PasswordContainer,
        CreateNewPassword,
        AdvicePasswordD,


    }
    
    public enum InputFieldType
    {
        UserInfo,
        Keys,
        PasswordData,
        Password
    }
}
