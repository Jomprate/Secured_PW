using System.IO;
using UnityEngine;
using UnityEditor;

public class OpenFilePanelExample : MonoBehaviour
{
    
   
    public void ViewOGGsFolder()
    {
        System.Diagnostics.Process.Start(Application.dataPath+"/OGGs/");
    }
}
