using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private PersistentSaveManager persistentSaveManager;
    [SerializeField] private DataSaveManager _dataSaveManager;
    [SerializeField] private UserInfo _userInfo;
    [SerializeField] private CreateNewUserController createNewUserController;
    [SerializeField] private PasswordContController passwordContController;
    [SerializeField] private CreateNewPassword _createNewPassword;
    //[SerializeField] private AdviceDeletePassword _adviceDeletePassword;
    
    
    
    

    private GetAllPanels _getAllPanels;


    private CanvasGroup WelcomeCanvas { get; set; }
    private CanvasGroup CreateNewUser { get; set; }
    private CanvasGroup PasswordContainer { get; set; }
    private CanvasGroup CreateNewPw { get; set; }
    private CanvasGroup AdviceC { get; set; }
    
    private CanvasGroup SettingsC { get; set; }

    private void Awake()
    {
        instance = this;
        AppEvents.Instance.OnAppStateChange += ChangeGameStateE;
        _getAllPanels = FindObjectOfType<GetAllPanels>();
        _getAllPanels.Initialize();
        
        
    }

    private void Start()
    {
        
       
        SetAllPanels();
        ChangeGameStateE(Enums.AppStates.Initialization);
        
    }

    public void SetAllPanels()
    {
        WelcomeCanvas = _getAllPanels.CanvasV[0].CanvasGroupP;
        CreateNewUser = _getAllPanels.CanvasV[1].CanvasGroupP;
        PasswordContainer = _getAllPanels.CanvasV[2].CanvasGroupP;
        CreateNewPw = _getAllPanels.CanvasV[3].CanvasGroupP;
        AdviceC = _getAllPanels.CanvasV[4].CanvasGroupP;
        SettingsC = _getAllPanels.CanvasV[5].CanvasGroupP;

        TurnOffAllPanels();
    }

    public void TurnOffAllPanels()
    {
        foreach (var canvasV in _getAllPanels.CanvasV)
        {
            canvasV.SetPanelState(false);
            if (canvasV.gameObject.GetComponent<TabInputField>() != null)
            {
                canvasV.gameObject.GetComponent<TabInputField>().EnableScript(false);
                
            }
            
        }
    }
   
    public void TurnOnAllPanels()
    {
        foreach (var canvasV in _getAllPanels.CanvasV)
        {
            canvasV.SetPanelState(true);
        }
    }
    
    
    public void ChangeGameStateE(Enums.AppStates gameState)
    {
        switch (gameState)
        {
            case Enums.AppStates.Initialization: Initialization();
                break;
            case Enums.AppStates.Welcome: WelcomeCanvasSec();
                break;
            case Enums.AppStates.CreateNewUser: CreateNewUserSec();
                break;
            case Enums.AppStates.PasswordCont: PasswordContSec();
                break;
            case Enums.AppStates.CreateNewPw: CreateNewPwSec();
                break;
            case Enums.AppStates.AdvicePw: AdviceSec(Enums.AdviceType.Password);
                break;
            case Enums.AppStates.AdviceUserNoPw: AdviceSec(Enums.AdviceType.UserNoPw);
                break;
            case Enums.AppStates.AdviceUserWithPw: AdviceSec(Enums.AdviceType.UserWithPw);
                break;
            case Enums.AppStates.AdviceVerifyAccess: AdviceSec(Enums.AdviceType.VerifyAccess);
                break;
            case Enums.AppStates.Settings: SettingsSec();
                break;
            case Enums.AppStates.StartGame:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    }

    public void Initialization()
    {
        persistentSaveManager.Initialize();
        _userInfo.Initialize();
        createNewUserController.Initialize();
        passwordContController.Initialize();
        _createNewPassword.Initialize();
        ChangeGameStateE(Enums.AppStates.Welcome);
    }

    public void WelcomeCanvasSec()
    {
        TurnOffAllPanels();
        passwordContController.RemoveCont();
        SetCanvasState.SetState(true,WelcomeCanvas);
        createNewUserController.UpdateUsers();
        
        /*createNewUserController.ResetUserConsole();*/
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        //_checkUserPassword.EnableScript(false);
        //WelcomeCanvas.gameObject.GetComponent<TabInputField>().EnableScript(true);
        PasswordContController.Instance.FillCont();
        CreateNewPassword.Instance.EnableScript(false);
        
    }
    
    public void CreateNewUserSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,CreateNewUser);
        _userInfo.ResetConsole();
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(true);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(true);
        CreateNewPassword.Instance.EnableScript(false);
    }

    public void PasswordContSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,PasswordContainer);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        CreateNewPw.gameObject.GetComponent<TabInputField>().EnableScript(false);
        //_checkUserPassword.EnableScript(false);
        CreateNewPassword.Instance.EnableScript(false);
    }

    public void CreateNewPwSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,CreateNewPw);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        CreateNewPw.gameObject.GetComponent<TabInputField>().EnableScript(true);
        CreateNewPassword.Instance.EnableScript(true);
        //_checkUserPassword.EnableScript(false);
    }
    
    public void AdviceSec(Enums.AdviceType type)
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,AdviceC);
        switch (type)
        {
            case Enums.AdviceType.Password:
                AdviceC.gameObject.AddComponent<Advice_DeletePassword>();
                break;
            case Enums.AdviceType.UserNoPw:
                AdviceC.gameObject.AddComponent<Advice_DeleteUserNoPw>();
                break;
            case Enums.AdviceType.UserWithPw:
                AdviceC.gameObject.AddComponent<Advice_DeleteUserWithPw>();
                break;
            case Enums.AdviceType.VerifyAccess:
                AdviceC.gameObject.AddComponent<Advice_VerifyAccess>();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        CreateNewPw.gameObject.GetComponent<TabInputField>().EnableScript(true);
        //_checkUserPassword.EnableScript(false);
    }

    public void SettingsSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,SettingsC);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
    }
    
}
