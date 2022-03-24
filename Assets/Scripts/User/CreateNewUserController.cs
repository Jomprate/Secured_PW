using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(CNU_FillUsersContent))]
[RequireComponent(typeof(CNU_SetIndexForUsers))]
public class CreateNewUserController : MonoBehaviour
{
    private CNU_FillUsersContent _cnuFillUsersContent;
    private CNU_SetIndexForUsers _cnuSetIndexForUsers;
    
    
    [SerializeField] private GameObject userPrefab;
    [SerializeField] private Transform contentP;
    [SerializeField] private UserInfo userInfo;
    [SerializeField] private Button createUser_btn;
    [SerializeField] private Button return_Btn;
    [HideInInspector] public List<Transform> childrenInContentP;

    public static CreateNewUserController instance;
    public CreateDirectory _createDirectory;

    
    
    
    public void Initialize()
    {
        
        
        instance = this;
        return_Btn.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);});
        createUser_btn.onClick.AddListener(() => { Create();});

        _cnuFillUsersContent = GetComponent<CNU_FillUsersContent>();
        _cnuSetIndexForUsers = GetComponent<CNU_SetIndexForUsers>();

    }
    

    public void Create()
    {
        userInfo.CheckNewUserData();
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
            userInfo.UserAccessPath = dsm._Path;
            udic.SetPath(userInfo.UserAccessPath);
            
            switch (userInfo.Encrypt)
            {
                case true: 
                    psm.CreateNewUser(true);
                    dsm.CreatePersonalData(dsm.SaveFileName,userInfo.UserPassword,true);
                    break;
                case false: 
                    psm.CreateNewUser(false);
                    dsm.CreatePersonalData(dsm.SaveFileName,userInfo.UserPassword,false);
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

    private void SetIndex()
    {
        _cnuFillUsersContent.FillContent(contentP,childrenInContentP);
        _cnuSetIndexForUsers.SetIndex(childrenInContentP);
    }
    
    
    
    
}
