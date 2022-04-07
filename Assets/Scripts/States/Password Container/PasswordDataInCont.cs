using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordDataInCont : MonoBehaviour
{
    public int mIndexNumber;
    private TextMeshProUGUI _idTMP;
    private Button _thisBtn;
    private Button _deleteThisPw;

    private void Awake()
    {
        mIndexNumber = 0;
        _thisBtn = GetComponent<Button>();
        _idTMP = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _deleteThisPw = transform.GetChild(2).GetComponent<Button>();
        _thisBtn.onClick.AddListener(() => { SetPasswordInfoInCons.instance.SetPasswordInfo(mIndexNumber); });
        _deleteThisPw.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.AdvicePw);
            Advice_DeletePassword.Instance.SetPasswordInfo(mIndexNumber,gameObject); });
    }
    
    public void SetPasswordData(string id)
    {
        _idTMP.text = id;
    }
}
