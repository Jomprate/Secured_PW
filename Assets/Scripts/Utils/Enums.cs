using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Enums
{
    public enum AppStates
    {
    
        Initialization,
        Welcome,
        CreateNewUser,
        PasswordCont,
        CreateNewPw,
        AdvicePw,
        AdviceUserNoPw,
        AdviceUserWithPw,
        AdviceVerifyAccess,
        Settings,
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
        Settings


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
