using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
[RequireComponent(typeof(CNP_CreateNewPw))]
public class CreateNewPassword : MonoBehaviour
{
    public static CreateNewPassword Instance;
    private CNP_CreateNewPw _cnpCreateNewPw;

    [SerializeField] private Button createNewPwBtn;
    [SerializeField] private Button returnBtn;
    private GetInputFields _getInputFields;
    [HideInInspector] public List<TMP_InputField> tmpInputFields;
    
    private InputManager inputManager;
    private InputAction _uiInputs;
    
    public string PasswordId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Description { get; set; }
   

    public void Initialize() {
        Instance = this;
        _cnpCreateNewPw = GetComponent<CNP_CreateNewPw>();
        
        if (_getInputFields == null) { _getInputFields = GetComponent<GetInputFields>(); }
        
        tmpInputFields = _getInputFields.tmpInputFields;
        
        createNewPwBtn.onClick.AddListener(() => { CreateNewPw(); });
        returnBtn.onClick.AddListener(() => { ReturnV(); });
        
        inputManager = InputManager.instance;
        _uiInputs = inputManager.userInputs.UIInputs.EnterKey;
        
        tmpInputFields[0].Select();
        _cnpCreateNewPw.SetNeeded(Instance,tmpInputFields);
    }
    public void EnableScript(bool enable) {
        switch (enable) {
            case true: _uiInputs.performed +=  EnterKey; 
                break;
            case false: _uiInputs.performed -=  EnterKey; 
                break;
        }
    }
    private void EnterKey(InputAction.CallbackContext context) => CreateNewPw();
    
    private void CreateNewPw() {
        _cnpCreateNewPw.CreateNewPw();
    }
    private void ReturnV() {
        GameManager.instance.ChangeGameStateE(Enums.AppStates.PasswordCont);
    }
    
}
