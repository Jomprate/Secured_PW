using TMPro;
using UnityEngine;

public class CNU_CreateNewUser : MonoBehaviour
{
    public static void AddNewUser(Transform content, GameObject prefab, UserInfo usI,CreateDirectory crD)
    {
        var dsm = DataSaveManager.instance;
        var psm = PersistentSaveManager.Instance;
        dsm.SaveFileName = dsm.RestSaveFileName;
        var go = Instantiate(prefab, content);
        var udic = go.gameObject.GetComponent<UserDataInCont>();
        
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = usI.UserName;
            
        usI.UserId = psm.saveUsersObject.createdIds.ids[psm.saveUsersObject.createdUsers.createdU];
            
        udic.SetId(usI.UserId); udic.SetEncryptedB(usI.Encrypt);
        usI.encrypt = usI.Encrypt;
        udic.SetUsingPw(usI.UsePassword);
        usI.usePassword = usI.UsePassword;
        
            
        dsm.SaveFileName += usI.UserId;
            
        crD.CreateNotEn(dsm.FolderName,dsm.SaveFileName,dsm.FileExtension);
        dsm._Path = crD.NormalPath;
        usI.UserAccessPath = dsm._Path;
        udic.SetPath(usI.UserAccessPath);
        
        switch (usI.Encrypt)
        {
            case true: 
                psm.CreateNewUser(true);
                dsm.CreatePersonalData(dsm.SaveFileName,usI.UserPassword,true);
                break;
            case false: 
                psm.CreateNewUser(false);
                dsm.CreatePersonalData(dsm.SaveFileName,usI.UserPassword,false);
                break;
        }
        psm.Save();
        dsm.Save();
            
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        
    }
}
