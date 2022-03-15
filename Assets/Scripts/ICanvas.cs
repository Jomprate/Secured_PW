using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICanvas 
{
    CanvasGroup CanvasGroupP { get; set; }
    Enums.PanelType PanelType { get; set; }

 
    void SetPanelState(bool state);

}
