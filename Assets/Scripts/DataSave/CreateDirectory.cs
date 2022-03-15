using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CreateDirectory : MonoBehaviour
{
    public string NormalPath { get; set; }
    public string EncryptedPath { get; set; }
    
    public void Create(string folderName,string sFName,string enFName, string fExt ) {
        Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName));
        NormalPath =
            Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName + "/" + sFName + fExt);
        EncryptedPath =
            Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName + "/" + enFName + fExt);
    }
    public void CreateNotEn(string folderName,string sFName, string fExt ) {
        Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName));
       
        NormalPath =
            Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName + "/" + sFName + fExt);
    }
    
    public void CreateEn(string folderName,string enFName, string fExt ) {
        Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName));
       
        EncryptedPath =
            Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + folderName + "/" + enFName + fExt);
    }
}
