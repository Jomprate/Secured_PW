using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateNewUserController : MonoBehaviour
{
    [SerializeField] private GameObject userPrefab;
    [SerializeField] private Transform contentP;
    [SerializeField] private UserInfo userInfo;
    [SerializeField] private Button createUser_btn;
    [SerializeField] private Button return_Btn;

    private SaveUsersObject _saveUsersObject;

    public static CreateNewUserController instance;
    public CreateDirectory _createDirectory;

    public void Initialize()
    {
        instance = this;
        return_Btn.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome); });
        _saveUsersObject = PersistentSaveManager.instance.saveUsersObject;
        createUser_btn.onClick.AddListener(() => { Create();});
    }
    

    public void Create()
    {
        userInfo.CheckNewUserInfo();
        if (userInfo.UserAccepted)
        {
            var DSM = DataSaveManager.instance;
            var PSM = PersistentSaveManager.instance;
            DSM.SaveFileName = DSM.RestSaveFileName;
            var go = Instantiate(userPrefab, contentP);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = userInfo.UserName;
            
            userInfo.UserId = PSM.saveUsersObject.createdIds.ids[PSM.saveUsersObject.createdUsers.createdU];
            go.gameObject.GetComponent<UserDataInCont>().SetId(userInfo.UserId);
            
            
            go.gameObject.GetComponent<UserDataInCont>().SetEncryptedB(userInfo.Encrypt);
            userInfo.encrypt = userInfo.Encrypt;
            DSM.SaveFileName += userInfo.UserId;
            _createDirectory.CreateNotEn(DSM.FolderName,DSM.SaveFileName,DSM.FileExtension);
            DSM._normalPath = _createDirectory.NormalPath;
            //userInfo.userAccessPath = DSM._normalPath;
            Debug.Log("user info form creation"+userInfo.userAccessPath);
            switch (userInfo.Encrypt)
            {
                case true: PSM.CreateNewUserWithEnData();
                    break;
                case false: PSM.CreateNewUserWithoutEnData();
                    break;
            }
            GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
            
            
            
            userInfo.userAccessPath = DSM._normalPath;
            
            go.gameObject.GetComponent<UserDataInCont>().SetPath(userInfo.userAccessPath);
            if (userInfo.Encrypt)
            {
                DSM.CreatePersonalDataEn(DataSaveManager.instance.SaveFileName);
            }
            else
            {
                DSM.CreatePersonalDataNotEn(DataSaveManager.instance.SaveFileName);
            }
            
            DSM.Save();
            PersistentSaveManager.instance.Save();
            
        }
        
        
    }
    
    

    public void UpdateUsers()
    {
        for (int i = 0; i < PersistentSaveManager.instance.saveUsersObject.activeUsers.actUsers; i++)
        {
            GameObject go = Instantiate(userPrefab, contentP);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                PersistentSaveManager.instance.saveUsersObject.userDataL[i].userName;
            var UDC = go.GetComponent<UserDataInCont>();
            UDC.id = PersistentSaveManager.instance.saveUsersObject.userDataL[i].userId;
            UDC.path = PersistentSaveManager.instance.saveUsersObject.userDataL[i].userAccessPath;
            UDC.encrypted = PersistentSaveManager.instance.saveUsersObject.userDataL[i].userEncrypt;

        }
    }
    
}
