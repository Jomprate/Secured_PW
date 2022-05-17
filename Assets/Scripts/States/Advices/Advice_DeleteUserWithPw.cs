using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Advice_DeleteUserWithPw : AdvicesAbs
{
    public static Advice_DeleteUserWithPw Instance;
    private BlinkRed _blinkRed;
    private GameObject _goToDelete;
    private int _id;
    private string path;
    
    public override void Awake()
    {
        gameObject.AddComponent<BlinkRed>();
        _blinkRed = GetComponent<BlinkRed>();
        
        titleTextId = "Advice_DUWP_Title";
        messageTextId = "Advice_DUWP_Message";
        continueBtnTextId = "Advice_DUWP_ContBtn";
        returnBtnTextId = "Return";
        requirePw = true;
        
        base.Awake();
        Instance = this;
        InputFieldPw.text = string.Empty;
        
    }

    protected override void EnterKey(InputAction.CallbackContext context) => Continue();

    public void UpdateInfo(int uid,string p,GameObject go) {
        _id = uid;
        _goToDelete = go;
        path = p;
    }
    public override void CheckInsertedPassword() {
        var psm = PersistentSaveManager.Instance;
        var gm = GameManager.instance;
        
        if (InputFieldPw.text.Trim() == psm.GetCurrentUserPassword(_id)) {
            UDIC_DeleteUser.DeleteU(_id,_goToDelete);
            PersistentSaveManager.Instance.DeleteUserPw(path);
            EnableScript(false);
            Destroy(_goToDelete);
            Destroy(_blinkRed);
            Destroy(this);
            gm.ChangeGameStateE(Enums.AppStates.Welcome);
        }
        else {
            _blinkRed.BlinkT(InputFieldPw);
            InputFieldPw.text = string.Empty;
        }
    }

    protected override void Continue() {
        
        CheckInsertedPassword();
    }

    protected override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        EnableScript(false);
        Destroy(_blinkRed);
        Destroy(this);
    }
}
