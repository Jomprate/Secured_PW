using TMPro;
using UnityEngine;

public class UICheckTextLenght : MonoBehaviour
{
    public bool CheckTextL(TMP_InputField inputText,int longRequired)
    {
        return inputText.text.Trim().Length > longRequired;
    }
}
