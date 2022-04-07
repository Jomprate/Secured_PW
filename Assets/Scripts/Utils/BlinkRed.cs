using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BlinkRed : MonoBehaviour
{
    public void BlinkT(TMP_InputField inputField)
    {
        Image img = inputField.gameObject.GetComponent<Image>();
        Color redC = Color.red;
        Color whiC = Color.white;
        StartCoroutine(BlinkC());
        
        IEnumerator BlinkC() {
            while (true)
            {
                img.color = redC;
                yield return new WaitForSeconds(0.2f);
                img.color = whiC;
                StopAllCoroutines();
                yield return false;
            }
        }

    }
    
}
