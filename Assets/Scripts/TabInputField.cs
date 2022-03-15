using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GetInputFields))]
public class TabInputField : MonoBehaviour
{
    public InputManager _inputManager;
    public GetInputFields _getInputFields;
    public List<TMP_InputField> _inputFields;

    public int InputSelected;

    private InputAction uiInputs;

    public void Awake()
    {
        _getInputFields = GetComponent<GetInputFields>();
        _inputManager = InputManager.instance;
        uiInputs = _inputManager.userInputs.UIInputs.TabInputChange;
        
        _inputFields = _getInputFields.GetFieldsW();
        EnableScript(false);
    }

    public void EnableScript(bool enable)
    {
        switch (enable)
        {
            case true: uiInputs.performed +=  ChangeInputSelected; 
                break;
            case false: uiInputs.performed -=  ChangeInputSelected; 
                break;
        }
        
    }

    private void ChangeInputSelected(InputAction.CallbackContext context)
    {
        Debug.Log("Tab Pressed");
        if (InputSelected >= _inputFields.Count -1)  {
            InputSelected = 0;
        }else InputSelected += 1;
        SelectInputField();
    }

    private void SelectInputField()
    {
        _inputFields[InputSelected].Select();
    }
    
    
    
}
