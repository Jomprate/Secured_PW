using System;
using System.Collections.Generic;

[Serializable]
public class SaveUsersObject
{
    public ActiveUsers activeUsers;
    public List<UserData> userDataL;
    public CreatedIds createdIds;
}

[Serializable]
public class ActiveUsers {
    public int actUsers;
}

[Serializable]
public class CreatedIds {
    public List<int> ids;
}

[Serializable]
public class UserData
{
    public int userId;
    public string userAccessPath;
    public string userName;
    public string userPassword;
    public bool userUseEncryption;
    public bool userUsePassword;
    
    public UserData(int userId,string userAccessPath,string userName,string userPassword,bool userUseEncryption, bool userUsePassword)
    {
        this.userId = userId;
        this.userAccessPath = userAccessPath;
        this.userName = userName;
        this.userPassword = userPassword;
        this.userUseEncryption = userUseEncryption;
        this.userUsePassword = userUsePassword;
    }
    
}