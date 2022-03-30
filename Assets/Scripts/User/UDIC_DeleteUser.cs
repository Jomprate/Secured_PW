using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDIC_DeleteUser : MonoBehaviour
{
    public static void DeleteU(int id, GameObject goToDelete)
    {
        var psm = PersistentSaveManager.Instance;
        psm.saveUsersObject.userDataL.RemoveAt(psm.GetCurrentUserPosition(id));
        
        psm.Save();
        Destroy(goToDelete);
        
    }
    
}
