using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GetInputFields))]
public class TabInputField : MonoBehaviour
{
    public InputManager inputManager;
    public GetInputFields getInputFields;
    public List<TMP_InputField> inputFields;

    public int inputSelected;

    private InputAction _uiInputs;

    public void Awake()
    {
        getInputFields = GetComponent<GetInputFields>();
        inputManager = InputManager.instance;
        _uiInputs = inputManager.userInputs.UIInputs.TabInputChange;
        
        inputFields = getInputFields.GetFieldsW();
        EnableScript(false);
    }

    public void EnableScript(bool enable) {
        switch (enable) {
            case true: _uiInputs.performed +=  ChangeInputSelected; 
                break;
            case false: _uiInputs.performed -=  ChangeInputSelected; 
                break;
        }
    }

    private void ChangeInputSelected(InputAction.CallbackContext context) {
        if (inputFields.Count >= 1)
        {
            if (inputSelected >= inputFields.Count -1)  {
                inputSelected = 0;
            }else inputSelected += 1;
            SelectInputField();
        }
        
    }

    private void SelectInputField() => inputFields[inputSelected].Select();
}
