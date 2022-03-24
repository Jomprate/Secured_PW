using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Text;
using System.Security.Cryptography;


public static class AESHandler
{
    
    
    
    
    

    
    //AES - Encription 
    public static string AesEncryption(string inputData)
    {
        string key = "A60A5770FE5E7AB200BA9CFC94E4E8B0"; //set any string of 32 chars
        string iv = "1234567887654321"; //set any string of 16 chars
        
        
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = Encoding.ASCII.GetBytes(key);
        AEScryptoProvider.IV = Encoding.ASCII.GetBytes(iv);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;

        byte[] txtByteData = Encoding.ASCII.GetBytes(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateEncryptor(AEScryptoProvider.Key, AEScryptoProvider.IV);

        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return Convert.ToBase64String(result);
    }

    //AES -  Decryption
    public static string AesDecryption(string inputData)
    {
        string key = "A60A5770FE5E7AB200BA9CFC94E4E8B0"; //set any string of 32 chars
        string iv = "1234567887654321"; //set any string of 16 chars
        
        AesCryptoServiceProvider AEScryptoProvider = new AesCryptoServiceProvider();
        AEScryptoProvider.BlockSize = 128;
        AEScryptoProvider.KeySize = 256;
        AEScryptoProvider.Key = Encoding.ASCII.GetBytes(key);
        AEScryptoProvider.IV = Encoding.ASCII.GetBytes(iv);
        AEScryptoProvider.Mode = CipherMode.CBC;
        AEScryptoProvider.Padding = PaddingMode.PKCS7;

        byte[] txtByteData = Convert.FromBase64String(inputData);
        ICryptoTransform trnsfrm = AEScryptoProvider.CreateDecryptor();

        byte[] result = trnsfrm.TransformFinalBlock(txtByteData, 0, txtByteData.Length);
        return Encoding.ASCII.GetString(result);
    }
}
