using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Advice_VerifyPassword : AdvicesAbs
{
    public static Advice_VerifyPassword Instance;
    private BlinkRed _blinkRed;
    private GameObject _goToDelete;
    private int _id;
    private string path;
    
    public override void Awake()
    {
        gameObject.AddComponent<BlinkRed>();
        _blinkRed = GetComponent<BlinkRed>();
        
        titleText = "Verificacion";
        messageText = "Bienvenido, pero antes de acceder para visualizar las contraseñas\n\ndebes insertar la contraseña de tu usuario";
        requirePw = true;
        base.Awake();
        Instance = this;
        
    }

    public override void CheckInsertedPassword() {
        
        var psm = PersistentSaveManager.Instance;
        var gm = GameManager.instance;
        
        if (InputFieldPw.text.Trim() == psm.GetCurrentUserPassword(_id)) {
            UDIC_DeleteUser.DeleteU(_id,_goToDelete);
            PersistentSaveManager.Instance.DeleteUserPw(path);
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
        Destroy(_blinkRed);
        Destroy(this);
    }
}
