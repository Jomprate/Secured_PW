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
        
        go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = usI.newUser.UserName;
            
        //usI.newUser.UserId = psm.saveUsersObject.createdIds.ids[psm.saveUsersObject.createdUsers.createdU];
        usI.newUser.UserId = CreateRandomId.UniqueRandomInt();
            
        udic.SetId(usI.newUser.UserId); udic.SetEncryptedB(usI.newUser.UseEncryption); udic.SetUsingPw(usI.newUser.UsePassword);
        
        
            
        dsm.SaveFileName += usI.newUser.UserId;
            
        crD.CreateNotEn(dsm.FolderName,dsm.SaveFileName,dsm.FileExtension);
        dsm._Path = crD.NormalPath;
        usI.newUser.UserAccessPath = dsm._Path;
        udic.SetPath(usI.newUser.UserAccessPath);
        
        switch (usI.newUser.UseEncryption)
        {
            case true: 
                psm.CreateNewUser(true);
                dsm.CreatePersonalData(dsm.SaveFileName,usI.newUser.UserPassword,true);
                break;
            case false: 
                psm.CreateNewUser(false);
                dsm.CreatePersonalData(dsm.SaveFileName,usI.newUser.UserPassword,false);
                break;
        }
        psm.Save();
        dsm.Save();
            
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        
    }
}
