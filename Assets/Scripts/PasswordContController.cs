using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordContController : MonoBehaviour
{
    public static PasswordContController instance;
    [SerializeField] private Transform contentTr;
    [SerializeField] private GameObject passwordPrefab;

    public void Initialize()
    {
        instance = this;
    }
    
    public void AddNewPassword(string id)
    {
        GameObject go;
        go = Instantiate(passwordPrefab, contentTr);
        go.GetComponent<PasswordDataInCont>().SetPasswordData(id);
        
        go.transform.SetParent(contentTr);
    }

    public void FillCont()
    {
        RemoveCont();
        foreach (var passwordData in DataSaveManager.instance.saveDataObject.PasswordDataL)
        {
            AddNewPassword(passwordData.passwordId);
        }
        
    }

    public void RemoveCont()
    {
        foreach (Transform child in contentTr)
        {
            Destroy(child.gameObject);
        }
            
    }
    

}
