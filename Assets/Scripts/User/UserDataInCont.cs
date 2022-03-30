using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class UserDataInCont : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI idTMP;
    private Button thisBtn;
    [SerializeField] private Button deleteUserBtn;
    public int id;
    public string path;
    public bool encrypted;
    public bool usingPw;
    public int m_IndexNumber;
    private PersistentSaveManager psm;
    private GameManager gm;

    private void Start()
    {
        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { ImPressed(); });
        
        if (usingPw)
        {
            deleteUserBtn.onClick.AddListener(() => { gm.ChangeGameStateE(Enums.AppStates.AdviceUserWithPw);Advice_DeleteUserWithPw.Instance.UpdateInfo(id,path,this.gameObject); });
        }
        else
        {
            //deleteUserBtn.onClick.AddListener(() => { PersistentSaveManager.Instance.DeleteUserNoPw(path); DeleteUser(); });
            deleteUserBtn.onClick.AddListener(() => { gm.ChangeGameStateE(Enums.AppStates.AdviceUserNoPw);Advice_DeleteUserNoPw.Instance.UpdateInfo(id,path,this.gameObject); });
        }
        
    }

    public void ImPressed() {
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        DataSaveManager.instance.SetPathToWork(path,encrypted);
        /*GameManager.instance.ChangeGameStateE(Enums.AppStates.CheckUser);
        CheckUserPassword.instance.SetInfoToWork(id);*/
        GameManager.instance.ChangeGameStateE(Enums.AppStates.AdviceVerifyAccess);
        Advice_VerifyAccess.Instance.SetInfoToWork(id);
    }
    
    private void DeleteUser() => UDIC_DeleteUser.DeleteU(id,gameObject);

    private void DeleteUserB()
    {
        
    }
    
    public void SetPath(string p) => path = p;
    public void SetEncryptedB(bool encrypt) => encrypted = encrypt;
    public void SetUsingPw(bool usingPassword) => usingPw = usingPassword;
    
    public void SetPasswordData(string id)
    {
        idTMP.text = id;
    }

    public void SetId(int i) => id = i;
}
