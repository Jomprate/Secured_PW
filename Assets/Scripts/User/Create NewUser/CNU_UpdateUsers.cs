using TMPro;
using UnityEngine;

public class CNU_UpdateUsers : MonoBehaviour
{
    public static void UpdateUsers(Transform content, GameObject preFab)
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }
        var PSM = PersistentSaveManager.Instance;
        for (int i = 0; i < PSM.saveUsersObject.activeUsers.actUsers; i++)
        {
            GameObject go = Instantiate(preFab, content);
            go.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                PSM.saveUsersObject.userDataL[i].userName;
            var UDC = go.GetComponent<UserDataInCont>();
            UDC.id = PSM.saveUsersObject.userDataL[i].userId;
            UDC.path = PSM.saveUsersObject.userDataL[i].userAccessPath;
            UDC.encrypted = PSM.saveUsersObject.userDataL[i].userUseEncryption;
            UDC.usingPw = PSM.saveUsersObject.userDataL[i].userUsePassword;

        }
    }
}
