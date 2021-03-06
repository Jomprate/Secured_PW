using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class CreateNewUserController : MonoBehaviour
{
    
    [SerializeField] private GameObject userPrefab;
    [SerializeField] private Transform contentP;
    [SerializeField] private UserInfo userInfo;
    [SerializeField] private Button createUserBtn;
    [SerializeField] private Button returnBtn;
    [HideInInspector] public List<Transform> childrenInContentP;

    
    public CreateDirectory createDirectory;

    private InputManager _inputManager;
    private InputAction _uiInputs;

    public void Initialize()
    {
        returnBtn.onClick.AddListener(() => { GameManager.instance.ChangeGameStateE(Enums.AppStates.Welcome);});
        createUserBtn.onClick.AddListener(() => { Create();});

        _inputManager = InputManager.instance;
        _uiInputs = _inputManager.userInputs.UIInputs.EnterKey;
    }

    public void EnableScript(bool enable) {
        switch (enable) {
            case true: _uiInputs.performed +=  EnterKey; 
                break;
            case false: _uiInputs.performed -=  EnterKey; 
                break;
        }
    }

    private void EnterKey(InputAction.CallbackContext context) => Create();
    

    private void Create() {
        userInfo.CheckNewUserData();
        switch (userInfo.UserAccepted)
        {
            case true: CNU_CreateNewUser.AddNewUser(contentP,userPrefab,userInfo,createDirectory);
                break;
            case false:
                break;
        }
    }

    public void UpdateUsers() {
        CNU_UpdateUsers.UpdateUsers(contentP,userPrefab);
        SetIndex();
    }

    private void SetIndex() {
        CNU_FillUsersContent.FillContent(contentP,childrenInContentP);
        //CNU_SetIndexForUsers.SetUsersIndex(childrenInContentP);
    }

    
    
}
