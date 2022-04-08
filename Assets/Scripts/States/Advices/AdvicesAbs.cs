using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class AdvicesAbs : MonoBehaviour, IAdvice,UsePW
{
    public InputManager InputManager { get; set; }
    public InputAction _uiInputs;
    
    public Transform parentT;

    public string titleText;

    public string messageText;

    public string continueBtnText;
    
    public TextMeshProUGUI Title { get; set; }
    public TextMeshProUGUI Message { get; set; }
    public TextMeshProUGUI ContinueBtnTmp { get; set; }
    public Button ContinueBtn { get; set; }
    public Button ReturnBtn { get; set; }

    public bool RequirePw { get; set; }
    public bool requirePw;
    public TMP_InputField InputFieldPw { get; set; }
    public virtual void Awake()
    {
        InputManager = InputManager.instance;
        _uiInputs = InputManager.userInputs.UIInputs.EnterKey;
        GetNeeded();
        SetButtonsV();
        RequirePw = requirePw;
        ShowHidePw();
        SetTexts();
        EnableScript(true);
    }

   
    
    private void GetNeeded()
    {
        parentT = transform.GetChild(0).GetChild(1);
        Title = parentT.GetChild(0).GetComponent<TextMeshProUGUI>();
        Message = parentT.GetChild(1).GetComponent<TextMeshProUGUI>();
        ContinueBtn = parentT.GetChild(2).GetComponent<Button>();
        ReturnBtn = parentT.GetChild(3).GetComponent<Button>();
        InputFieldPw = parentT.GetChild(4).GetComponent<TMP_InputField>();

        ContinueBtnTmp = ContinueBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

    }

    private void SetButtonsV() {
        ContinueBtn.onClick.AddListener(Continue);
        ReturnBtn.onClick.AddListener(Return);
    }

    private void SetTexts() {
        Title.text = titleText;
        Message.text = messageText;
        ContinueBtnTmp.text = continueBtnText;
    }
    
    private void ShowHidePw() => InputFieldPw.gameObject.SetActive(RequirePw);

    public virtual void EnableScript(bool enable) {
        switch (enable) {
            case true: _uiInputs.performed +=  EnterKey; 
                break;
            case false: _uiInputs.performed -=  EnterKey; 
                break;
        }
    }

    protected virtual void EnterKey(InputAction.CallbackContext context){} 

    public virtual void CheckInsertedPassword()
    {
    }

    public virtual void Continue()
    {
    }

    public virtual void Return()
    {
    }
}