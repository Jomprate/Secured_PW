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
        return_Btn.onClick.AddListener(() =>
        {
            GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
            //Debug.Log("return pRESSED");
        });
        _saveUsersObject = PersistentSaveManager.Instance.saveUsersObject;
        createUser_btn.onClick.AddListener(() => { Create();});
    }
    

    public void Create()
    {
        userInfo.CheckNewUserInfo();
        if (userInfo.UserAccepted)
        {
            var DSM = DataSaveManager.instance;
            var PSM = PersistentSaveManager.Instance;
            DSM.SaveFileName = DSM.RestSaveFileName;
            var go = Instantiate(userPrefab, contentP);
            
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = userInfo.UserName;
            
            userInfo.UserId = PSM.saveUsersObject.createdIds.ids[PSM.saveUsersObject.createdUsers.createdU];
            go.gameObject.GetComponent<UserDataInCont>().SetId(userInfo.UserId);
            
            go.gameObject.GetComponent<UserDataInCont>().SetEncryptedB(userInfo.Encrypt);
            userInfo.encrypt = userInfo.Encrypt;
            
            //DSM.SaveFileName += userInfo.UserId;
            DSM.SaveFileName += userInfo.UserId;
            
            
            
            
            _createDirectory.CreateNotEn(DSM.FolderName,DSM.SaveFileName,DSM.FileExtension);
            DSM._normalPath = _createDirectory.NormalPath;
            userInfo.userAccessPath = DSM._normalPath;
            go.gameObject.GetComponent<UserDataInCont>().SetPath(userInfo.userAccessPath);
            
            switch (userInfo.Encrypt)
            {
                case true: 
                    PSM.CreateNewUserWithEnData();
                    DSM.CreatePersonalDataEn(DataSaveManager.instance.SaveFileName);
                    break;
                case false: 
                    PSM.CreateNewUserWithoutEnData();
                    DSM.CreatePersonalDataNotEn(DataSaveManager.instance.SaveFileName);
                    break;
            }
            PSM.Save();
            DSM.Save();
            
            GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
            
        }
        //GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        
    }
    
    

    public void UpdateUsers()
    {
        ResetUserConsole();
        var PSM = PersistentSaveManager.Instance;
        for (int i = 0; i < PSM.saveUsersObject.activeUsers.actUsers; i++)
        {
            GameObject go = Instantiate(userPrefab, contentP);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                PSM.saveUsersObject.userDataL[i].userName;
            var UDC = go.GetComponent<UserDataInCont>();
            UDC.id = PSM.saveUsersObject.userDataL[i].userId;
            UDC.path = PSM.saveUsersObject.userDataL[i].userAccessPath;
            UDC.encrypted = PSM.saveUsersObject.userDataL[i].userEncrypt;

        }
    }

    public void ResetUserConsole()
    {
        foreach (Transform child in contentP)
        {
            Destroy(child.gameObject);
        }
    }
    
}
