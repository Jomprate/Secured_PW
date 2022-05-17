using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;
using System.IO;

public class LanguageManager : MonoBehaviour {

    
    [Header("Languages")]
    public static LanguageManager instance;

    public LanguageReader langReader { get; private set; } 
    
    public string currentLanguage = "English"; //This variable will contain as a string the current language that we've selected

    public delegate void LanguageChange();
    public static event LanguageChange OnLanguageChange;

    
    private void Awake() {
        instance = this;
        //SelectLanguage("Espanol");
        OpenLocalXML("English");
    }

    public void OpenLocalXML(string language) {
        langReader = null;
        currentLanguage = null;

        switch (language) {
            case "English":
                langReader = new LanguageReader(Resources.Load("Lang/ENG") as TextAsset, "English");
                break;
            case "Espanol":
                langReader = new LanguageReader(Resources.Load("Lang/ESP") as TextAsset, "Espanol");
                break;
            
            default:
#if UNITY_EDITOR
                Debug.LogWarning("This language doesn't exist: " + language);
#endif
                langReader = new LanguageReader(Resources.Load("Lang/ENG") as TextAsset, "English");
                break;
        }

        currentLanguage = language;
        if (OnLanguageChange != null) {
            OnLanguageChange();
        }
    }

    public void SelectLanguage(string language) {
        if (language != currentLanguage) { //If we are not selecting the same language we have right now
            OpenLocalXML(language); //we open locally
        }

    }

}
