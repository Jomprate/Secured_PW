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
    public int m_IndexNumber;
    public int id;
    public string path;
    public bool encrypted;

    private void Start()
    {
        m_IndexNumber = 0;
        m_IndexNumber= transform.GetSiblingIndex();
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { ImPressed(); });
        deleteUserBtn.onClick.AddListener(() => { PersistentSaveManager.Instance.DeleteUser(path); DeleteUser(); });
        
    }

    public void ImPressed() {
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        DataSaveManager.instance.SetPathToWork(path,encrypted);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.CheckUser);
        CheckUserPassword.instance.SetInfoToWork(id);
    }

    private void DeleteUser() => UDIC_DeleteUser.DeleteU(id,gameObject);
    public void SetPath(string p) => path = p;
    public void SetEncryptedB(bool encrypt) => encrypted = encrypt;

    public void SetPasswordData(string id)
    {
        idTMP.text = id;
    }

    public void SetId(int i) => id = i;
}
