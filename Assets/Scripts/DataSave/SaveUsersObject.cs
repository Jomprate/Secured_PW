using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveUsersObject
{
    public CreatedUsers createdUsers;
    public ActiveUsers activeUsers;
    public List<UserData> userDataL;
    public CreatedIds createdIds;
}
[Serializable]
public class CreatedUsers {
    public int createdU;
}


[Serializable]
public class ActiveUsers {
    public int actUsers;
}


[Serializable]
public class CreatedIds
{
    public List<int> ids;

    public CreatedIds(List<int> ids)
    {
        this.ids = ids;
    }
}

[Serializable]
public class UserData
{
    public int userId;
    public string userAccessPath;
    public bool userEncrypt;
    public string userName;
    public string userPassword;
    
    public UserData(int userId,string userAccessPath,bool userEncrypt,string userName,string userPassword)
    {
        this.userId = userId;
        this.userAccessPath = userAccessPath;
        this.userEncrypt = userEncrypt;
        this.userName = userName;
        this.userPassword = userPassword;
    }
    
}