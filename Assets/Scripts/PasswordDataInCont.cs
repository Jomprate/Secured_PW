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

    private void Start()
    {
        
        m_IndexNumber = 0;
        m_IndexNumber= transform.GetSiblingIndex();
        //Output the Sibling Index to the console
        Debug.Log("Sibling Index : " + transform.GetSiblingIndex());
        //thisBtn.onClick.AddListener(SetPasswordInfoInCons.instance.SetPasswordInfo(m_IndexNumber));
        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { SetPasswordInfoInCons.instance.SetPasswordInfo(m_IndexNumber); });
    }

    public void SetPasswordData(string id)
    {
        idTMP.text = id;
    }
}
