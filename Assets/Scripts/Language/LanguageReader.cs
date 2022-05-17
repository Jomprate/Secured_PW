using System;
using System.Collections;
using System.Xml;
using UnityEngine;


public class LanguageReader {
    
    Hashtable XML_Strings; //The hashtable that we create to contain the data

    public LanguageReader(TextAsset xmlFile, string language) {
        SetLocalLanguage(xmlFile.text, language);
    }

    ///Read a XML stored on the computer
    public void SetLocalLanguage(string xmlContent, string language) {
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(xmlContent);
        XML_Strings = new Hashtable();
        XmlElement element = xml.DocumentElement[language];
        if (element != null) {
            var elemEnum = element.GetEnumerator();

            while (elemEnum.MoveNext()) {
                XML_Strings.Add((elemEnum.Current as XmlElement).GetAttribute("name"), (elemEnum.Current as XmlElement).InnerText.Replace(@"\n", Environment.NewLine));
            }
        } else { 
            Debug.LogError("The specified language does not exist: " + language);
        }
    }

    /// Get a string from the hastable by the index gived in it.
    public string getString(string _name) {
        if (!XML_Strings.ContainsKey(_name)) {
            Debug.LogWarning("This string is not present in the XML file where you're reading: " + _name);
            return "";
        }
        return (string)XML_Strings[_name];
    }

}