
using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem;
[DefaultExecutionOrder(-100)]
public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    public UserInputs userInputs;

    public void Awake()
    {
        instance = this;
        Debug.Log("InputManager Awake");
        userInputs = new UserInputs();
        userInputs.Enable();
    }

    private void OnEnable()
    {
        userInputs.Enable();
    }

    private void OnDisable()
    {
        userInputs.Disable();
    }

    
}

