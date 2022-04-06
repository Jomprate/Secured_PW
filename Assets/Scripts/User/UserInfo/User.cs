using System;

[Serializable]
public class User
{
    public int UserId;
    public string UserAccessPath;
    public string UserName;
    public string UserPassword;
    public bool UsePassword;
    public bool UseEncryption;
    //public bool encrypt;
    
    //public bool usePassword;

    public User(int userId,string userAccessPath,string userName,string userPassword,bool useEncryption,bool usePassword)
    {
        this.UserId = userId;
        this.UserAccessPath = userAccessPath;
        this.UserName = userName;
        this.UserPassword = userPassword;
        this.UsePassword = usePassword;
        this.UseEncryption = useEncryption;
        

    }
    
    public User(){}
}
