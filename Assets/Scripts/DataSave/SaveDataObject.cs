using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]

public class SaveDataObject
{
    
    public List<PasswordData> PasswordDataL;
    public TravelsExecuted TravelsExe;
}




[Serializable]
public class TravelsExecuted
{
    public int TravelsQ;
}

/*[Serializable]
public class UserData
{
    public int userId;
    public string userName;
    public string userPassword;
    
    public UserData(string userName,string userPassword)
    {
        
        this.userName = userName;
        this.userPassword = userPassword;
    }
}*/

