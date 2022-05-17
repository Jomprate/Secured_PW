using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Advice_DeleteUserNoPw : AdvicesAbs
{
    public static Advice_DeleteUserNoPw Instance;
    private int mIndexNumber;
    private GameObject _goToDelete;
    private int _id;
    private string path;

    public override void Awake()
    {
        titleTextId = "Advice_DUNP_Title";
        messageTextId = "Advice_DUNP_Message";
        continueBtnTextId = "Advice_DUNP_ContBtn";
        returnBtnTextId = "Return";
        requirePw = false;
        base.Awake();
        Instance = this;
        
    }

    

    protected override void EnterKey(InputAction.CallbackContext context) => Continue();


    public void UpdateInfo(int uid,string p,GameObject go) {
        _id = uid;
        _goToDelete = go;
        path = p;
    }

    protected override void Continue() {
        var psm = PersistentSaveManager.Instance;
        var gm = GameManager.instance;
        UDIC_DeleteUser.DeleteU(_id,_goToDelete);
        psm.DeleteUserNoPw(path);
        EnableScript(false);
        Destroy(_goToDelete);
        Destroy(this);
        gm.ChangeGameStateE(Enums.AppStates.Welcome);
    }

    protected override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        EnableScript(false);
        Destroy(this);
    }
}
