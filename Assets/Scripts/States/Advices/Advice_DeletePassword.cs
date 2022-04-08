using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Advice_DeletePassword : AdvicesAbs
{
    public static Advice_DeletePassword Instance;
    private int _mIndexNumber;
    private GameObject _goToDelete;

    public override void Awake()
    {
        titleText = "Borrar Contraseña";
        messageText = "En Realidad deseas borrar esta contraseña?\n\nNo podras recuperarla despues de esto";
        continueBtnText = "Borrar";
        requirePw = false;
        base.Awake();
        Instance = this;
        
    }


    protected override void EnterKey(InputAction.CallbackContext context)
    {
        Continue();
    }

    public void SetPasswordInfo(int index, GameObject go) {
        _mIndexNumber = index;
        _goToDelete = go;
    }
    public override void Continue() {
        DataSaveManager.instance.DeletePassword(_mIndexNumber);
        Destroy(_goToDelete);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }

    public override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }
}
