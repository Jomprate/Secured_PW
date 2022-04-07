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
        
        titleText = "Borrar Usuario";
        messageText = "En Realidad deseas borrar este Usuario?\n\nNo podras recuperarlo despues de esto, y dado que este usuario posee contraseña debes insertarla";
        continueBtnText = "Borrar";
        requirePw = true;
        
        base.Awake();
        Instance = this;
        InputFieldPw.text = string.Empty;
        
    }

    public override void EnterKey(InputAction.CallbackContext context) => Continue();

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
    
    public override void Continue() {
        
        CheckInsertedPassword();
    }

    public override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        EnableScript(false);
        Destroy(_blinkRed);
        Destroy(this);
    }
}
