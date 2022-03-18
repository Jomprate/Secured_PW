using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordDataInCont : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idTMP;
    public int m_IndexNumber;
    private Button thisBtn;
    [ SerializeField] private Button deleteThisPW;

    private void Awake()
    {
        m_IndexNumber = 0;
        //UpdateIndex();
        //m_IndexNumber= transform.GetSiblingIndex();
       
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { SetPasswordInfoInCons.instance.SetPasswordInfo(m_IndexNumber); });
        deleteThisPW.onClick.AddListener(() => { DataSaveManager.instance.DeletePassword(m_IndexNumber); DeleteThis(); });
    }

    

    public void DeleteThis()
    {
        Destroy(gameObject);
        
    }

    public void UpdateIndex()
    {
        
        m_IndexNumber = GetSiblingIndex(transform, transform.parent);
        Debug.Log(transform.parent.name);

    }
    
    public int GetSiblingIndex(Transform child, Transform parent)
    {
        for (int i = 0; i < parent.childCount; ++i)
        {
            Debug.Log(child.GetInstanceID() + " - " + parent.GetChild(i).GetInstanceID());
            if (child.GetInstanceID() == parent.GetChild(i).GetInstanceID())
                return i;
        }
        Debug.LogWarning("Child doesn't belong to this parent.");
        return 0;
    }
    
    public void SetPasswordData(string id)
    {
        idTMP.text = id;
    }
}
