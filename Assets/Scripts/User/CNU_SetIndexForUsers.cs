using System.Collections.Generic;
using UnityEngine;

public class CNU_SetIndexForUsers : MonoBehaviour {
    public void SetIndex(List<Transform> transformsList) {
        for (var i = 0; i < transformsList.Count; i++) {
            transformsList[i].GetComponent<UserDataInCont>().m_IndexNumber = i;
        }
    }
}
