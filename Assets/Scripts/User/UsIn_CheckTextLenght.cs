using TMPro;
using UnityEngine;


public class UsIn_CheckTextLenght : MonoBehaviour
{
    public static bool CheckTextL(TMP_InputField inputText,int longRequired,BlinkRed br)
    {
        if (inputText.text.Trim().Length > longRequired)
        {
            return true;
        }
        else
        {
            br.BlinkT(inputText);
            return false;
        }
    }
}
