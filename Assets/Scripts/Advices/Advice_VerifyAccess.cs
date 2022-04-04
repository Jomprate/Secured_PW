using UnityEngine;

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
        
        TitleText = "Verificacion";
        MessageText = "Bienvenido, pero antes de acceder para visualizar las contraseñas\n\ndebes insertar la contraseña de tu usuario";
        ContinueBtnText = "Acceder";
        
        requirePw = true;
        base.Awake();
        InputFieldPw.text = string.Empty;
        Instance = this;
        psm = PersistentSaveManager.Instance;
        gm = GameManager.instance;
        
    }

    
    
    public void SetInfoToWork(int userId) {
        _id = userId;
        PersistentSaveManager.Instance.GetCurrentUserPosition(_id);
        CheckIfNeedPw();
    }
    private void CheckIfNeedPw() {
        var usingPw = psm.GetPasswordNeeded(_id);
        if (!usingPw) { gm.ChangeGameStateE(Enums.AppStates.PasswordCont); }
    }
    public override void CheckInsertedPassword() {

        if (InputFieldPw.text.Trim() == psm.GetCurrentUserPassword(_id)) {
            Debug.Log("password accepted");
            gm.ChangeGameStateE(Enums.AppStates.PasswordCont);
        }
        else {
            _blinkRed.BlinkT(InputFieldPw);
            InputFieldPw.text = string.Empty;
        }
    }
    
    public override void Continue() => CheckInsertedPassword();

    public override void Return() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);
        Destroy(_blinkRed);
        Destroy(this);
    }
}
