using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public abstract class AdvicesAbs : MonoBehaviour
{
    public InputManager InputManager { get; set; }
    public InputAction _uiInputs;
    private LanguageManager lang;
    
    public Transform parentT;

    public string titleTextId;

    public string messageTextId;

    public string continueBtnTextId;
    public string returnBtnTextId;
    
    public TextMeshProUGUI Title { get; set; }
    public TextMeshProUGUI Message { get; set; }
    public TextMeshProUGUI ContinueBtnTmp { get; set; }
    public TextMeshProUGUI ReturnBtnTmp { get; set; }
    public Button ContinueBtn { get; set; }
    public Button ReturnBtn { get; set; }

    public bool RequirePw { get; set; }
    public bool requirePw;
    public TMP_InputField InputFieldPw { get; set; }
    
    public TextMeshProUGUI InputFieldPwPh { get; set; }
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

    private void Start()
    {
        lang = LanguageManager.instance;
        LanguageManager.OnLanguageChange += ChangeMessage;
        ChangeMessage();
    }

    public void ChangeMessage()
    {
        Title.text = lang.langReader.getString(titleTextId);
        Message.text = lang.langReader.getString(messageTextId);
        ContinueBtnTmp.text = lang.langReader.getString(continueBtnTextId);
        ReturnBtnTmp.text = lang.langReader.getString(returnBtnTextId);
    }

    private void OnDestroy()
    {
        LanguageManager.OnLanguageChange -= ChangeMessage;
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
        ReturnBtnTmp = ReturnBtn.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void SetButtonsV() {
        ContinueBtn.onClick.AddListener(Continue);
        ReturnBtn.onClick.AddListener(Return);
    }

    private void SetTexts() {
        Title.text = titleTextId;
        Message.text = messageTextId;
        ContinueBtnTmp.text = continueBtnTextId;
    }
    
    private void ShowHidePw() => InputFieldPw.gameObject.SetActive(RequirePw);

    protected void EnableScript(bool enable) {
        switch (enable) {
            case true: _uiInputs.performed +=  EnterKey; break;
            case false: _uiInputs.performed -=  EnterKey; break;
        }
    }

    protected virtual void EnterKey(InputAction.CallbackContext context){} 

    public virtual void CheckInsertedPassword() { }

    protected virtual void Continue() { }

    protected virtual void Return() { }
}
