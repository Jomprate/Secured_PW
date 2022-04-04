using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppEvents : MonoBehaviour
{
    public static AppEvents Instance;
    
    public void Awake()
    {
        Instance = this;
        
    }

    public event Action<Enums.AppStates> OnAppStateChange;

    private void ChangeAppStateE() {
        OnAppStateChange?.Invoke(Enums.AppStates.Initialization);
    }

    
}
