using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetAllPanels : MonoBehaviour
{
    public CanvasV[] CanvasV { get; set; }
    public CanvasV[] canvasVs;

    public void Initialize() {
        canvasVs = GetComponentsInChildren<CanvasV>();
        CanvasV = canvasVs;
    }
    
}
