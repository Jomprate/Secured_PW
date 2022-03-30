using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Advice_DeletePassword : AdvicesAbs
{
    public static Advice_DeletePassword Instance;
    private int mIndexNumber;
    private GameObject goToDelete;

    public override void Awake()
    {
        TitleText = "Borrar Contraseña";
        MessageText = "En Realidad deseas borrar esta contraseña?\n\nNo podras recuperarla despues de esto";
        ContinueBtnText = "Borrar";
        requirePw = false;
        base.Awake();
        Instance = this;
        
    }

    public void SetPasswordInfo(int index, GameObject go) {
        mIndexNumber = index;
        goToDelete = go;
    }
    public override void Continue() {
        DataSaveManager.instance.DeletePassword(mIndexNumber);
        Destroy(goToDelete);
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }

    public override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
        Destroy(this);
    }
}
