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
    
    
    public string Path { get; set; }
    public string np;
    
    //private const string FolderName = "SD";
    public string FolderName {get; private set; }
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
        SaveFileName = "User";
        RestSaveFileName = "User";
        FolderName = "SecuredPasswordData";
        FileExtension = ".SS";
        
        
    }
    
    public void Start() {
        _createDirectory.Create(FolderName,SaveFileName,EnSaveFileName,FileExtension);
        Path = _createDirectory.NormalPath;
        
        saveDataObject = new SaveDataObject {
            PasswordDataL = new List<PasswordData>()
        };
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);;
       
        Load(); 
    }

    public void SetPathToWork(string path, bool encrypted) {
        Path = path;
        Encrypted = encrypted;
        
        Load();
        PasswordContController.Instance.FillCont();
    }
    
    private SaveDataObject CreateCleanSaveDataObject() {
        saveDataObject = new SaveDataObject {
            PasswordDataL = new List<PasswordData>(),
        };
        return saveDataObject;
    }
    

    

    public void Save()
    {
        saveDataObject = new SaveDataObject {
            PasswordDataL = saveDataObject.PasswordDataL,
        }; 
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);
         switch (Encrypted) {
             case true:
                 enJson = AESHandler.AesEncryption(enJson);
                 File.WriteAllText(Path,enJson);
                 return;
             case false:
                 File.WriteAllText(Path,json);
                 break;
         }
    }

    private void Load()
    {
        if (File.Exists(Path))
        {
            SaveDataObject loadedDataObject;
            string saveString = File.ReadAllText(Path);
            string saveEnString = File.ReadAllText(Path);
            switch (Encrypted)
            {
                case true:
                    saveEnString = AESHandler.AesDecryption(saveEnString);
                    saveEnString = AESHandler.AesDecryption(saveEnString);
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
    
    public void CreatePersonalData(string saveFileName, bool encrypted)
    {
        _createDirectory.CreateNotEn(FolderName,saveFileName,FileExtension);
        Path = _createDirectory.NormalPath;
        saveDataObject = CreateCleanSaveDataObject();
        json = JsonUtility.ToJson(saveDataObject);
        enJson = AESHandler.AesEncryption(json);;
        Encrypted = encrypted;
        Save();
    }
    
    public void CreateNewPasswordData() {
        var data = DSM_CreateNewPwData.CreateNewPasswordData(saveDataObject);
        saveDataObject.PasswordDataL.Add(data);
        Save();
        PasswordContController.Instance.AddNewPassword(data.passwordId);
    }
    
    public void DeletePassword(int index)
    {
        saveDataObject.PasswordDataL.RemoveAt(index);
        Save();
        PasswordContController.Instance.FillCont();
        
    }
}