using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserDataInCont : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idTMP;
    private Button thisBtn;
    public int m_IndexNumber;
    public int id;
    public string path;
    public bool encrypted;

    private void Start()
    {
        
        m_IndexNumber = 0;
        m_IndexNumber= transform.GetSiblingIndex();
        //Output the Sibling Index to the console
        //Debug.Log("Sibling Index : " + transform.GetSiblingIndex());

        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { ImPressed(); });
    }

    public void ImPressed()
    {
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        Debug.Log("resettedddddddddddddddd");
        DataSaveManager.instance.SetPathToWork(path,encrypted);
        
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
