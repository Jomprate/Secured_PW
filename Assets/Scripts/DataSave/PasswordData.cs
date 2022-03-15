
using System;

[Serializable]
public class PasswordData
{
    public string passwordId;
    public string email;
    public string userName;
    public string password;
    public string description;
    
    
    public PasswordData(string passwordId,string email,string userName,string password, string description)
    {
        this.passwordId = passwordId;
        this.email = email;
        this.userName = userName;
        this.password = password;
        this.description = description;
    }
}
