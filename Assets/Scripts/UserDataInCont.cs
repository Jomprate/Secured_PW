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

    public void ImPressed()
    {
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        DataSaveManager.instance.SetPathToWork(path,encrypted);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.CheckUser);
        CheckUserPassword.instance.SetInfoToWork(id);
        //CheckUserPassword.instance.CheckUser();
        //GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
    }

    public void DeleteUser()
    {
        Destroy(gameObject);
    }
    
    public void SetPath(string path)
    {
        this.path = path;
    }

    public void SetEncryptedB(bool encrypt)
    {
        encrypted = encrypt;
        //Debug.Log( "set encryptedB"+encrypted);
    }
    
    public void SetPasswordData(string id)
    {
        idTMP.text = id;
    }

    public void SetId(int id)
    {
        this.id = id;
    }
}
