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

    
    public CanvasGroup WelcomeCanvas { get; set; }
    public CanvasGroup CreateNewUser { get; set; }
    
    public CanvasGroup PasswordContainer { get; set; }

    public CanvasGroup CreateNewPw { get; set; }
    
    public CanvasGroup AdviceC { get; set; }

    private void Awake()
    {
        instance = this;
        AppEvents.Instance.OnAppStateChange += ChangeGameStateE;
        _getAllPanels = FindObjectOfType<GetAllPanels>();
        _getAllPanels.Initialize();
        
        
    }

    private void Start()
    {
        
        /*AppEvents.Instance.OnAppStateChange += ChangeGameStateE;
        _getAllPanels = FindObjectOfType<GetAllPanels>();
        _getAllPanels.Initialize();*/
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
    public void TurnOffPanelArray()
    {
        
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
            case Enums.AppStates.Initialization:
                persistentSaveManager.Initialize();
                _userInfo.Initialize();
                createNewUserController.Initialize();
                //_checkUserPassword.Initialize();
                passwordContController.Initialize();
                _createNewPassword.Initialize();
                //_adviceDeletePassword.Initialize();
                
                
                
                ChangeGameStateE(Enums.AppStates.Welcome);
                break;
            case Enums.AppStates.Welcome:
                WelcomeCanvasSec();
                PasswordContController.Instance.FillCont();
                break;
            case Enums.AppStates.MainMenu:
                break;
            case Enums.AppStates.CreateNewUser:
                CreateNewUserSec();
                break;
            /*case Enums.AppStates.CheckUser:
                CheckUserPasswordSec();
                break;*/
            case Enums.AppStates.PasswordCont:
                PasswordContSec();
                break;
            case Enums.AppStates.CreateNewPw:
                CreateNewPwSec();
                break;
            case Enums.AppStates.AdvicePw:
                AdviceSec(Enums.AdviceType.Password);
                break;
            case Enums.AppStates.AdviceUserNoPw:
                AdviceSec(Enums.AdviceType.UserNoPw);
                break;
            case Enums.AppStates.AdviceUserWithPw:
                AdviceSec(Enums.AdviceType.UserWithPw);
                break;
            case Enums.AppStates.AdviceCheckPw:
                AdviceSec(Enums.AdviceType.CheckPw);
                break;
            case Enums.AppStates.AdviceVerifyAccess:
                AdviceSec(Enums.AdviceType.VerifyAccess);
                break;
            case Enums.AppStates.StartGame:
                break;


            
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
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
        
    }
    
    public void CreateNewUserSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,CreateNewUser);
        _userInfo.ResetConsole();
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(true);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(true);
        //_checkUserPassword.EnableScript(false);
    }

    public void CheckUserPasswordSec()
    {
        TurnOffAllPanels();
        //SetCanvasState.SetState(true,CheckUserP);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        //_checkUserPassword.EnableScript(true);
    }

    public void PasswordContSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,PasswordContainer);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        CreateNewPw.gameObject.GetComponent<TabInputField>().EnableScript(false);
        //_checkUserPassword.EnableScript(false);
    }

    public void CreateNewPwSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,CreateNewPw);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(false);
        CreateNewUser.gameObject.GetComponent<CreateNewUserController>().EnableScript(false);
        CreateNewPw.gameObject.GetComponent<TabInputField>().EnableScript(true);
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
            case Enums.AdviceType.CheckPw:
                AdviceC.gameObject.AddComponent<Advice_VerifyPassword>();
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
    
    
}
