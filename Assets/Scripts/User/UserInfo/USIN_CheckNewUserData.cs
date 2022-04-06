using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class USIN_CheckNewUserData
{
    public static bool CheckData(bool usePassword,TMP_InputField unTMP,TMP_InputField pTMP,BlinkRed br)
    {
        return usePassword switch
        {
            true => USIN_CheckTextLenght.CheckTextL(unTMP, 3, br) 
                    && USIN_CheckTextLenght.CheckTextL(pTMP, 3, br),
            false => USIN_CheckTextLenght.CheckTextL(unTMP, 3, br)
        };
    }
}
