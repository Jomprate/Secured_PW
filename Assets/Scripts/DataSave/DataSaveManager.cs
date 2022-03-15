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
    
    
    public string _normalPath { get; set; }
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
        _normalPath = _createDirectory.NormalPath;
        
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AESEncryption(json);;

       
        Load(); 
        PasswordContController.instance.FillCont();
    }

    public void SetPathToWork(string path, bool encrypted)
    {
        Debug.Log("Encrypted in SetPath" + encrypted);
        _normalPath = path;
        np = _normalPath;
        Encrypted = encrypted;
        Debug.Log("Encrypted in SetPath" + Encrypted);
        Save();
        Load();
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        PasswordContController.instance.FillCont();
        
    }
    
    public void Initialize()
    {
        
    }

    

    public void CreatePersonalDataNotEn(string saveFileName)
    {
        _createDirectory.CreateNotEn(FolderName,saveFileName,FileExtension);
        _normalPath = _createDirectory.NormalPath;
        
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AESEncryption(json);;
        Save();
       
        //Load(); 
        
    }
    public void CreatePersonalDataEn(string saveFileName)
    {
        _createDirectory.CreateNotEn(FolderName,saveFileName,FileExtension);
        _normalPath = _createDirectory.NormalPath;
        
        
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = new List<PasswordData>(),
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AESEncryption(json);;
        Save();
       
        //Load(); 
        
    }

    

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.N))
        // {
        //     Save();
        // }
        // if (Input.GetKeyDown(KeyCode.P))
        // {
        //     DeleteSave();
        // }
    }

    

    public void LoadUsers()
    {
        
    }
    
    public void Save()
    {
        saveDataObject = new SaveDataObject
        {
            PasswordDataL = saveDataObject.PasswordDataL,
            
        }; 
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AESEncryption(json);
         if (Encrypted)
         {
             Debug.Log("access to encrypt");
             enJson = AESHandler.AESEncryption(enJson);
             File.WriteAllText(_normalPath,enJson);
         }
         else
         {  Debug.Log("access to dont encrypt");
             File.WriteAllText(_normalPath,json);
         }
        /*File.WriteAllText(_normalPath,json);
        File.WriteAllText(_encryptedPath,enJson);*/
        
    }

    public void Load()
    {
        if (File.Exists(_normalPath))
        {
            SaveDataObject loadedDataObject;
            string saveString = File.ReadAllText(_normalPath);
            string saveEnString = File.ReadAllText(_normalPath);
            switch (Encrypted)
            {
                case true:
                    saveEnString = AESHandler.AESDecryption(saveEnString);
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
            Load();
        }
        /*if (File.Exists(_normalPath) && File.Exists(_encryptedPath))
        {
            
            SaveDataObject loadedDataObject;
            string saveString = File.ReadAllText(_normalPath);
            string saveEnString = File.ReadAllText(_encryptedPath);
            if (Encrypt)
            {
                saveEnString = AESHandler.AESDecryption(saveEnString);
                loadedDataObject = JsonUtility.FromJson<SaveDataObject>(saveEnString);
            }
            else
            {
                loadedDataObject = JsonUtility.FromJson<SaveDataObject>(saveString);
            }

            saveDataObject.PasswordDataL = loadedDataObject.PasswordDataL;
            

            //Load();
        }
        else
        {
            Save();
            Load();
        }*/
        
    }

    public void DeleteSave()
    {
        saveDataObject.PasswordDataL.Clear();
        
        File.Delete(_normalPath);
        
        //Load();
        Save();
        
    }


    
    
    public void CreateNewPasswordData()
    {
        var createNewPassword = CreateNewPassword.instance;
        PasswordData data = new PasswordData(
            createNewPassword.passwordId,
            createNewPassword.email,
            createNewPassword.userName,
            createNewPassword.password,
            createNewPassword.description
        );
        
        saveDataObject.PasswordDataL.Add(data);
        Save();
        PasswordContController.instance.AddNewPassword(data.passwordId);

    }
    
    

    
    
    
    
}


