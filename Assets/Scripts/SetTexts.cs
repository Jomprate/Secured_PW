using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTexts : MonoBehaviour
{
    public StringBuilder stringBuilder;
    public GetInputFields _getInputFields;
    
    private void Awake()
    {
        _getInputFields = GetComponent<GetInputFields>();
        stringBuilder = FindObjectOfType<StringBuilder>();
    }

    public void SetKeyInputText()
    {
        _getInputFields.tmpInputFields[0].text = stringBuilder.CreateNewCharString();
    }

    public void SetIvInputText()
    {
        _getInputFields.tmpInputFields[1].text = stringBuilder.CreateNewIntString();
    }
}
