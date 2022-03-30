using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[RequireComponent(typeof(CreateDirectory))]
public class PersistentSaveManager : MonoBehaviour
{
   public static PersistentSaveManager Instance;
   
   private CreateDirectory _createDirectory;
   
   
   private string _encryptedPath;
   private const string FolderName = "SD";
   private const string EnSaveFileName = "enPersistent";
   private const string FileExtension = ".SS";

   public SaveUsersObject saveUsersObject;
   public string json;
   public string enJson;
   
   public void Initialize()
   {
      Instance = this;
      _createDirectory = GetComponent<CreateDirectory>();
      _createDirectory.CreateEn(FolderName,EnSaveFileName,FileExtension);
      _encryptedPath = _createDirectory.EncryptedPath;
      Needed();
   }

   private void Needed() {
      saveUsersObject = new SaveUsersObject
      {
         createdIds = new CreatedIds(CreateRandomId.GenerateRandom(10000,100000,1000000)),
         createdUsers = new CreatedUsers(),
         activeUsers = new ActiveUsers(),
         userDataL = new List<UserData>()
      };
      json = JsonUtility.ToJson(saveUsersObject);
      enJson = AESHandler.AesEncryption(json);
      
      Load();
   }
   
   public void Save() {
      saveUsersObject = new SaveUsersObject {
         createdIds = saveUsersObject.createdIds,
         createdUsers = saveUsersObject.createdUsers,
         activeUsers = saveUsersObject.activeUsers,
         userDataL = saveUsersObject.userDataL,
      }; 
      enJson = AESHandler.AesEncryption(JsonUtility.ToJson(saveUsersObject));
      
      File.WriteAllText(_encryptedPath,enJson);
   }

   private void Load() {
      if (File.Exists(_encryptedPath))
      {
         string saveEnString = File.ReadAllText(_encryptedPath);
         saveEnString = AESHandler.AesDecryption(saveEnString);
         
         SaveUsersObject loadedDataObject = JsonUtility.FromJson<SaveUsersObject>(saveEnString);

         saveUsersObject.activeUsers = loadedDataObject.activeUsers;
         saveUsersObject.createdIds = loadedDataObject.createdIds;
         saveUsersObject.createdUsers = loadedDataObject.createdUsers;
         saveUsersObject.userDataL = loadedDataObject.userDataL;
      }
      else
      {
         Save();
      }
   }

   private UserData CreateUserData() {
      var userInfo = UserInfo.instance;
      UserData data = new UserData(
         
         userInfo.UserId = saveUsersObject.createdIds.ids[saveUsersObject.createdUsers.createdU],
         userInfo.UserAccessPath,
         userInfo.UserEncrypt = userInfo.Encrypt,
         userInfo.UserName,
         userInfo.UserPassword,
         userInfo.UsePassword = userInfo.usePassword
         
      );
      
      
      return data;
   }
   
   public void CreateNewUser(bool encrypt)
   {
      UserData data = CreateUserData();
      
      data.userAccessPath = DataSaveManager.instance._Path;
      saveUsersObject.createdUsers.createdU += 1;
      saveUsersObject.activeUsers.actUsers += 1;
      saveUsersObject.userDataL.Add(data);

      switch (encrypt)
      {
         case true:
            _createDirectory.CreateEn(FolderName,EnSaveFileName,FileExtension);
            _encryptedPath = _createDirectory.EncryptedPath;
            break;
         case false:
            _createDirectory.CreateNotEn(FolderName,EnSaveFileName,FileExtension);
            _encryptedPath = _createDirectory.EncryptedPath;
            break;
      }

      Save();
   }

   #region Get Info from an Specific User
   
   public int GetCurrentUserPosition(int id) {
      var userData = saveUsersObject.userDataL.Find( x => x.userId == id);
      return saveUsersObject.userDataL.IndexOf(userData);
   }
   
   public bool GetPasswordNeeded(int id) {
      var userData = saveUsersObject.userDataL.Find( x => x.userId == id);
      return userData.userUsePassword;
   }
   
   public string GetCurrentUserPassword(int id) {
      var userData = saveUsersObject.userDataL.Find( x => x.userId == id);
      return userData.userPassword;;
   }
   
   #endregion
   public void DeleteUserNoPw(string path)
   {  saveUsersObject.activeUsers.actUsers -= 1;
      File.Delete(path);
      Save();
   }
   public void DeleteUserPw(string path)
   {  saveUsersObject.activeUsers.actUsers -= 1;
      File.Delete(path);
      Save();
   }
   
}
