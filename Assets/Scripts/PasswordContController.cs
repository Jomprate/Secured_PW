using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordContController : MonoBehaviour
{
    public static PasswordContController Instance;
    [SerializeField] private Transform contentTr;
    [SerializeField] private GameObject passwordPrefab;
    [SerializeField] private List<GameObject> passwordsObjs;

    public void Initialize()
    {
        Instance = this;
    }
    
    public void AddNewPassword(string id) {
        GameObject go = Instantiate(passwordPrefab, contentTr);
        go.GetComponent<PasswordDataInCont>().SetPasswordData(id);
        go.transform.SetParent(contentTr);
        passwordsObjs.Add(go);
        SetIndex();
    }

    private void SetIndex() {
        for (var i = 0; i < passwordsObjs.Count; i++) {
            passwordsObjs[i].GetComponent<PasswordDataInCont>().m_IndexNumber = i;
        }
    }
    
    public void FillCont() {
        RemoveCont();
        foreach (var passwordData in DataSaveManager.instance.saveDataObject.PasswordDataL) {
            AddNewPassword(passwordData.passwordId);
        }
    }

    public void RemoveCont() {
        passwordsObjs.Clear();
        foreach (Transform child in contentTr) {
            Destroy(child.gameObject);
        }
    }

}
