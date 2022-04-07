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
        titleText = "Borrar Usuario";
        messageText = "En Realidad deseas borrar este Usuario?\n\nNo podras recuperarlo despues de esto";
        continueBtnText = "Borrar";
        requirePw = false;
        base.Awake();
        Instance = this;
        
    }

    public override void EnterKey(InputAction.CallbackContext context) => Continue();


    public void UpdateInfo(int uid,string p,GameObject go) {
        _id = uid;
        _goToDelete = go;
        path = p;
    }
    
    public override void Continue() {
        var psm = PersistentSaveManager.Instance;
        var gm = GameManager.instance;
        UDIC_DeleteUser.DeleteU(_id,_goToDelete);
        psm.DeleteUserNoPw(path);
        EnableScript(false);
        Destroy(_goToDelete);
        Destroy(this);
        gm.ChangeGameStateE(Enums.AppStates.Welcome);
    }

    public override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        EnableScript(false);
        Destroy(this);
    }
}
