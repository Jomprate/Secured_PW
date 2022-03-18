using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[RequireComponent(typeof(CreateDirectory))]
public class DataSaveManager : MonoBehaviour
{
    public static DataSaveManager instance;

    private CreateDirectory _createDirectory;
    
    
    public string _Path { get; set; }
    public string np;
    
    //private const string FolderName = "SD";
    public string FolderName {get; set; }
    public  string SaveFileName { get; set; }
    public string RestSaveFileName { get; set; }
    
    //SaveFileName = "save";
    public string EnSaveFileName = "enSave";
    public string FileExtension { get; set; }
    
    public bool Encrypted { get; set; }
    
    
    public SaveDataObject saveDataObject;
    public string json;
    public string enJson;

    public bool Encrypt = false;

    private void Awake()
    {
        instance = this;
        _createDirectory = GetComponent<CreateDirectory>();
        SaveFileName = "save";
        RestSaveFileName = "save";
        FolderName = "SD";
        FileExtension = ".SS";
        
        
    }
    
    public void Start()
    {
        //Directory.CreateDirectory(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\" + FolderName));
        _createDirectory.Create(FolderName,SaveFileName,EnSaveFileName,FileExtension);
        _Path = _createDirectory.NormalPath;
        
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);;

       
        Load(); 
        
    }

    public void SetPathToWork(string path, bool encrypted)
    {
        _Path = path;
        np = _Path;
        Debug.Log(np);
        
        Encrypted = encrypted;
        Debug.Log("Encrypted in SetPath" + Encrypted);
        
        Load();
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        PasswordContController.instance.FillCont();
        
    }
    
    private void CreateSaveDataObject() {
        saveDataObject = new SaveDataObject {
            PasswordDataL = new List<PasswordData>(),
        };
    }
    

    public void CreatePersonalDataNotEn(string saveFileName)
    {
        _createDirectory.CreateNotEn(FolderName,saveFileName,FileExtension);
        _Path = _createDirectory.NormalPath;
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);
        Encrypted = false;
        Save();
       
        //Load(); 
        
    }

    public void CreatePersonalDataEn(string saveFileName)
    {
        _createDirectory.CreateNotEn(FolderName,saveFileName,FileExtension);
        _Path = _createDirectory.NormalPath;
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);;
        Encrypted = true;
        Save();
       
        //Load(); 
        
    }

    public void DeletePassword(int index)
    {
        saveDataObject.PasswordDataL.RemoveAt(index);
        Save();
        PasswordContController.instance.FillCont();
        
    }

    public void Save()
    {
        saveDataObject = new SaveDataObject {
            PasswordDataL = saveDataObject.PasswordDataL,
        }; 
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);
         switch (Encrypted)
         {
             case true:
                 enJson = AESHandler.AesEncryption(enJson);
                 File.WriteAllText(_Path,enJson);
                 return;
             case false:
                 File.WriteAllText(_Path,json);
                 break;
         }
    }

    public void Load()
    {
        if (File.Exists(_Path))
        {
            SaveDataObject loadedDataObject;
            string saveString = File.ReadAllText(_Path);
            string saveEnString = File.ReadAllText(_Path);
            switch (Encrypted)
            {
                case true:
                    Debug.Log(saveEnString);
                    saveEnString = AESHandler.AesDecryption(saveEnString);
                    saveEnString = AESHandler.AesDecryption(saveEnString);
                    Debug.Log(saveEnString);
                    loadedDataObject = JsonUtility.FromJson<SaveDataObject>(saveEnString);
                    saveDataObject.PasswordDataL = loadedDataObject.PasswordDataL;
                    Save();
                    break;
                case false:
                    loadedDataObject = JsonUtility.FromJson<SaveDataObject>(saveString);
                    saveDataObject.PasswordDataL = loadedDataObject.PasswordDataL;
                    Save();
                    break;
            }
            
        }
        else
        {
            Save();
        }
    }

    public void DeleteSave()
    {
        saveDataObject.PasswordDataL.Clear();
        
        File.Delete(_Path);
        
        //Load();
        Save();
        
    }
    
    public void CreateNewPasswordData()
    {
        var createNewPassword = CreateNewPassword.instance;
        PasswordData data = new PasswordData(
            createNewPassword.PasswordId,
            createNewPassword.Email,
            createNewPassword.UserName,
            createNewPassword.Password,
            createNewPassword.Description
        );
        
        saveDataObject.PasswordDataL.Add(data);
        Save();
        PasswordContController.instance.AddNewPassword(data.passwordId);

    }
    
    

    
    
    
    
}


