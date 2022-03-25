using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public static class ClipboardExtension
{
    
    public static void CopyToClipboard(string str)
    {
        GUIUtility.systemCopyBuffer = str;
    }
}
