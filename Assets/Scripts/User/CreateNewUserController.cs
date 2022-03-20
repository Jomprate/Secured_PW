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
    [SerializeField] private List<Transform> childrenInContentP;
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
            var dsm = DataSaveManager.instance;
            var psm = PersistentSaveManager.Instance;
            dsm.SaveFileName = dsm.RestSaveFileName;
            var go = Instantiate(userPrefab, contentP);
            var udic = go.gameObject.GetComponent<UserDataInCont>();
            
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = userInfo.UserName;
            
            userInfo.UserId = psm.saveUsersObject.createdIds.ids[psm.saveUsersObject.createdUsers.createdU];
            
            udic.SetId(userInfo.UserId); udic.SetEncryptedB(userInfo.Encrypt);
            userInfo.encrypt = userInfo.Encrypt;
            
            dsm.SaveFileName += userInfo.UserId;
            
            _createDirectory.CreateNotEn(dsm.FolderName,dsm.SaveFileName,dsm.FileExtension);
            dsm._Path = _createDirectory.NormalPath;
            userInfo.userAccessPath = dsm._Path;
            udic.SetPath(userInfo.userAccessPath);
            
            switch (userInfo.Encrypt)
            {
                case true: 
                    psm.CreateNewUserWithEnData();
                    dsm.CreatePersonalDataEn(DataSaveManager.instance.SaveFileName,userInfo.UserPassword);
                    break;
                case false: 
                    psm.CreateNewUserWithoutEnData();
                    dsm.CreatePersonalDataNotEn(DataSaveManager.instance.SaveFileName,userInfo.UserPassword);
                    break;
            }
            psm.Save();
            dsm.Save();
            
            GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
            
        }
        //GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        
    }
    
    

    public void UpdateUsers()
    {
        foreach (Transform child in contentP)
        {
            Destroy(child.gameObject);
        }
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
        SetIndex();
    }

    public void SetIndex()
    {
        FillContentP();
        for (int i = 0; i < childrenInContentP.Count; i++)
        {
            childrenInContentP[i].GetComponent<UserDataInCont>().m_IndexNumber = i;
        }
        
    }
    
    
    public void FillContentP()
    {   
        childrenInContentP.Clear();
        foreach (Transform child in contentP)
        {
            childrenInContentP.Add(child);
        }
    }
    
}
