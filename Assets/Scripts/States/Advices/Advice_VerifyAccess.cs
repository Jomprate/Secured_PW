using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Advice_VerifyAccess : AdvicesAbs
{
    public static Advice_VerifyAccess Instance;
    private BlinkRed _blinkRed;
    private GameObject _goToDelete;
    private int _id;
    private string path;
    
    private PersistentSaveManager psm;
    private GameManager gm;
    
    public override void Awake()
    {
        gameObject.AddComponent<BlinkRed>();
        _blinkRed = GetComponent<BlinkRed>();
        
        titleTextId = "Advice_VA_Title";
        messageTextId = "Advice_VA_Message";
        continueBtnTextId = "Advice_VA_ContBtn";
        returnBtnTextId = "Return";
        requirePw = true;
        base.Awake();
        InputFieldPw.text = string.Empty;
        InputFieldPw.image.color = Color.white;
        Instance = this;
        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
        
        InputFieldPw.Select();        
    }


    protected override void EnterKey(InputAction.CallbackContext context) => Continue();

    public void SetInfoToWork(int userId) {
        _id = userId;
        PersistentSaveManager.Instance.GetCurrentUserPosition(_id);
        CheckIfNeedPw();
    }
    private void CheckIfNeedPw() {
        var usingPw = psm.GetPasswordNeeded(_id);
        if (usingPw) return;
        gm.ChangeGameStateE(Enums.AppStates.PasswordCont); Destroy(_blinkRed); Destroy(this);
    }
    public override void CheckInsertedPassword() {
        if (InputFieldPw.text.Trim() == psm.GetCurrentUserPassword(_id)) {
            gm.ChangeGameStateE(Enums.AppStates.PasswordCont);
            InputFieldPw.text = string.Empty;
            Destroy(_blinkRed); EnableScript(false); Destroy(this);
        }
        else {
            Debug.Log(psm.GetCurrentUserPassword(_id));
            _blinkRed.BlinkT(InputFieldPw);
            InputFieldPw.text = string.Empty;
        }
    }

    protected override void Continue() {
        CheckInsertedPassword();
    }

    protected override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        Destroy(_blinkRed); EnableScript(false); Destroy(this);
    }
}
