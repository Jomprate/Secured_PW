using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CanvasGroup))]


public abstract class CanvasAbsV : MonoBehaviour,ICanvas
{
    public CanvasGroup CanvasGroupP { get; set; }
    public Enums.PanelType PanelType { get; set; }
    public Enums.PanelType panelType;

    
    private void Awake() {
        CanvasGroupP = GetComponent<CanvasGroup>();
        PanelType = panelType;
    }

    public void SetPanelState(bool state) {
        SetCanvasState.SetState(state,CanvasGroupP);
        
    }
    
}
