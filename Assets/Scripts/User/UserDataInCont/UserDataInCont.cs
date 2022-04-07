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
    //public int m_IndexNumber;
    private PersistentSaveManager psm;
    private GameManager gm;

    private void Start()
    {
        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { ImPressed(); });
        
        if (usingPw) {
            deleteUserBtn.onClick.AddListener(() => {
                gm.ChangeGameStateE(Enums.AppStates.AdviceUserWithPw);
                Advice_DeleteUserWithPw.Instance.UpdateInfo(id,path, gameObject);
            });
        }
        else {
            deleteUserBtn.onClick.AddListener(() => {
                gm.ChangeGameStateE(Enums.AppStates.AdviceUserNoPw);
                Advice_DeleteUserNoPw.Instance.UpdateInfo(id,path,gameObject);
            });
        }
        
    }

    private void ImPressed() {
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        DataSaveManager.instance.SetPathToWork(path,encrypted);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.AdviceVerifyAccess);
        Advice_VerifyAccess.Instance.SetInfoToWork(id);
        Advice_VerifyAccess.Instance.SetInfoToWork(id);
    }
    
    public void SetId(int i) => id = i;
    public void SetPath(string p) => path = p;
    public void SetEncryptedB(bool encrypt) => encrypted = encrypt;
    public void SetUsingPw(bool usingPassword) => usingPw = usingPassword;
    
    
}
