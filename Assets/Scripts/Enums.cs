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
        AdviceUserNoPw,
        AdviceUserWithPw,
        AdviceCheckPw,
        AdviceVerifyAccess,
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

    public enum AdviceType
    {
        Password,
        UserNoPw,
        UserWithPw,
        CheckPw,
        VerifyAccess
    }
    
    public enum InputFieldType
    {
        UserInfo,
        Keys,
        PasswordData,
        Password
    }
}
