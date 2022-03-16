using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckUserPassword : MonoBehaviour
{
    private GetInputFields _getInputFields;
    [SerializeField] private TMP_InputField passwordInput;

    public void Initialize()
    {
        _getInputFields = GetComponent<GetInputFields>();
        passwordInput = _getInputFields._tmpInputFields[0];
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(passwordInput.text.Trim());
        }
    }

    public void CheckUser()
    {
        if (passwordInput.text.Trim() == name)
        {
            
        }
    }
}
