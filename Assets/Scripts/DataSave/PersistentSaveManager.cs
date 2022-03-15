using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[RequireComponent(typeof(CreateDirectory))]
public class PersistentSaveManager : MonoBehaviour
{
   public static PersistentSaveManager instance;
   
   private CreateDirectory _createDirectory;
   
   private string _normalPath;
   private string _encryptedPath;
   private const string FolderName = "SD";

   
   //SaveFileName = "save";
   private const string EnSaveFileName = "enPersistent";
   private const string FileExtension = ".SS";

   public SaveUsersObject saveUsersObject;
   public string json;
   public string enJson;
   
   public bool Encrypt = false;


   public void Initialize()
   {
      instance = this;
      _createDirectory = GetComponent<CreateDirectory>();
      _createDirectory.CreateEn(FolderName,EnSaveFileName,FileExtension);
      _encryptedPath = _createDirectory.EncryptedPath;
      Needed();
   }
   
   private void Needed()
   {
      saveUsersObject = new SaveUsersObject
      {
         createdIds = new CreatedIds(CreateRandomId.GenerateRandom(100,1000,10000)),
         createdUsers = new CreatedUsers(),
         activeUsers = new ActiveUsers(),
         userDataL = new List<UserData>()
         
         
         
      };
      json = JsonUtility.ToJson(saveUsersObject);
      enJson = AESHandler.AESEncryption(json);
      
      //saveUsersObject.createdIdsL = CreateRandomId.GenerateRandom(5,1,5)); 
      
      Load();
   }

   
   private void Start()
   {
      /*saveUsersObject = new SaveUsersObject
      {
         createdIds = new CreatedIds(CreateRandomId.GenerateRandom(100,1000,10000)),
         createdUsers = new CreatedUsers(),
         activeUsers = new ActiveUsers(),
         userDataL = new List<UserData>()
         
         
         
      };
      json = JsonUtility.ToJson(saveUsersObject);
      enJson = AESHandler.instance.AESEncryption(json);
      
      //saveUsersObject.createdIdsL = CreateRandomId.GenerateRandom(5,1,5)); 
      
      Load();*/
      CreateNewUserController.instance.UpdateUsers();
   }
   
   
   
   
   
   public void Save()
   {
      saveUsersObject = new SaveUsersObject {
         createdIds = saveUsersObject.createdIds,
         createdUsers = saveUsersObject.createdUsers,
         activeUsers = saveUsersObject.activeUsers,
         userDataL = saveUsersObject.userDataL,
         
         
         
      }; 
      enJson = AESHandler.AESEncryption(JsonUtility.ToJson(saveUsersObject));
      
      File.WriteAllText(_encryptedPath,enJson);
   }
   
   public void Load()
   {
      if (File.Exists(_encryptedPath))
      {
         SaveUsersObject loadedDataObject;
         string saveEnString = File.ReadAllText(_encryptedPath);
         
         saveEnString = AESHandler.AESDecryption(saveEnString);
         loadedDataObject = JsonUtility.FromJson<SaveUsersObject>(saveEnString);

         saveUsersObject.activeUsers = loadedDataObject.activeUsers;
         saveUsersObject.createdIds = loadedDataObject.createdIds;
         saveUsersObject.createdUsers = loadedDataObject.createdUsers;
         saveUsersObject.userDataL = loadedDataObject.userDataL;
         
         //Load();
      }
      else
      {
         Save();
         Load();
      }
        
   }
   
   public void CreateNewUserWithoutEnData()
   {
      var userInfo = UserInfo.instance;
      UserData data = new UserData(
         
         userInfo.UserId = saveUsersObject.createdIds.ids[saveUsersObject.createdUsers.createdU],
         userInfo.userAccessPath,
         userInfo.userEncrypt,
         userInfo.UserName,
         userInfo.UserPassword
      );
      data.userAccessPath = DataSaveManager.instance._normalPath;
      saveUsersObject.createdUsers.createdU += 1;
      saveUsersObject.activeUsers.actUsers += 1;
      
      saveUsersObject.userDataL.Add(data);
      
      Debug.Log(data.userAccessPath);
      
      
      _createDirectory.CreateEn(FolderName,EnSaveFileName,FileExtension);
      _encryptedPath = _createDirectory.EncryptedPath;
      Save();
      
   }
   
   public void CreateNewUserWithEnData()
   {
      var userInfo = UserInfo.instance;
      UserData data = new UserData(
         userInfo.UserId = saveUsersObject.createdIds.ids[saveUsersObject.createdUsers.createdU],
         userInfo.userAccessPath,
         userInfo.userEncrypt,
         userInfo.UserName,
         userInfo.UserPassword
      );
      //data.userId = saveUsersObject.createdIds.ids[saveUsersObject.createdUsers.createdU];
      saveUsersObject.createdUsers.createdU += 1;
      saveUsersObject.activeUsers.actUsers += 1;
      saveUsersObject.userDataL.Add(data);
      
      _createDirectory.CreateEn(FolderName,EnSaveFileName,FileExtension);
      _encryptedPath = _createDirectory.EncryptedPath;
      Save();
      
   }
   
   
   
}