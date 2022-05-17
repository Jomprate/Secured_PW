using UnityEngine;
using UnityEngine.InputSystem;


public class Advice_DeletePassword : AdvicesAbs
{
    public static Advice_DeletePassword Instance;
    private int _mIndexNumber;
    private GameObject _goToDelete;

    public override void Awake()
    {
        titleTextId = "Advice_DP_Title";
        messageTextId = "Advice_DP_Message";
        continueBtnTextId = "Advice_DP_ContBtn";
        returnBtnTextId = "Return";
        requirePw = false;
        base.Awake();
        Instance = this;
        
    }
    
    


    protected override void EnterKey(InputAction.CallbackContext context) {
        Continue();
    }

    public void SetPasswordInfo(int index, GameObject go) {
        _mIndexNumber = index;
        _goToDelete = go;
    }

    protected override void Continue() {
        DataSaveManager.instance.DeletePassword(_mIndexNumber);
        Destroy(_goToDelete);
        SetPasswordInfoInCons.instance.ResetPasswordInfo();
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }

    protected override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }
}
