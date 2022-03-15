using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPanels : MonoBehaviour
{
    
    public void TurnOffPanelArray(CanvasGroup[] canvasGroups)
    {
        foreach (var canvasGroup in canvasGroups)
        {
            SetCanvasState.SetState(false,canvasGroup);
        }
        
    }
}
