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
    
    
    
    public GameObject[] panels;
    public List<GameObject> panelsL;

    private GetAllPanels _getAllPanels;

    public CanvasGroup[] canvases;
    
    public CanvasGroup WelcomeCanvas { get; set; }
    public CanvasGroup welcomeCanvas;
    public CanvasGroup CreateNewUser { get; set; }
    public CanvasGroup createNewUser;
    public CanvasGroup SelectEnKeysUser { get; set; }
    public CanvasGroup selectEnKeysUser;
    
    public CanvasGroup CheckUserInfo { get; set; }
    public CanvasGroup checkUserInfo;
    
    public CanvasGroup PasswordContainer { get; set; }
    public CanvasGroup passwordContainer;
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
        welcomeCanvas = WelcomeCanvas;
        CreateNewUser = _getAllPanels.CanvasV[1].CanvasGroupP;
        createNewUser = CreateNewUser;
        PasswordContainer = _getAllPanels.CanvasV[2].CanvasGroupP;
        passwordContainer = PasswordContainer;

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
                passwordContController.Initialize();
                ChangeGameStateE(Enums.AppStates.Welcome);
                break;
            case Enums.AppStates.Welcome:
                WelcomeCanvasSec();
                break;
            case Enums.AppStates.MainMenu:
                break;
            case Enums.AppStates.CreateNewUser:
                CreateNewUserSec();
                break;
            case Enums.AppStates.PasswordCont:
                PasswordContSec();
                
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
        SetCanvasState.SetState(true,WelcomeCanvas);
        //WelcomeCanvas.gameObject.GetComponent<TabInputField>().EnableScript(true);
        
    }
    
    public void CreateNewUserSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,CreateNewUser);
        CreateNewUser.gameObject.GetComponent<TabInputField>().EnableScript(true);
    }

    public void PasswordContSec()
    {
        TurnOffAllPanels();
        SetCanvasState.SetState(true,passwordContainer);
        
    }
    
    
}
