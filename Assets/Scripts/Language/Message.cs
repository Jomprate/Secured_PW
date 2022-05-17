using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;


public class Message : MonoBehaviour {

    public LanguageManager lang;
    //public Text _text;
    public TextMeshProUGUI _text;
    [SerializeField] private string id;

    private void Awake()
    {
        _text = gameObject.GetComponent<TextMeshProUGUI>();
        
    }

    private void Start()
    {
        lang = LanguageManager.instance;
        LanguageManager.OnLanguageChange += ChangeMessage;
        Invoke(nameof(ChangeMessage),2);
    }


    public void ChangeMessage()
    {
        _text.text = lang.langReader.getString(id);
    }
    
    public void ChangeMultiLanguageMessage(string code) {
        //gameObject.SetActive(true);
        _text.text = lang.langReader.getString(code);
    }

    private void OnDisable()
    {
        LanguageManager.OnLanguageChange -= ChangeMessage;
    }
}
