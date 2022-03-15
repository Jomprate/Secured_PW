using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UserDataInCont : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI idTMP;
    public int m_IndexNumber;
    public int id;
    private Button thisBtn;

    private void Start()
    {
        
        m_IndexNumber = 0;
        m_IndexNumber= transform.GetSiblingIndex();
        //Output the Sibling Index to the console
        Debug.Log("Sibling Index : " + transform.GetSiblingIndex());

        thisBtn = GetComponent<Button>();
        thisBtn.onClick.AddListener(() => { SetPasswordInfoInCons.instance.SetPasswordInfo(m_IndexNumber); });
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
