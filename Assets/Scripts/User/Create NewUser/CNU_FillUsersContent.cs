using System.Collections.Generic;
using UnityEngine;

public class CNU_FillUsersContent : MonoBehaviour {
    public static void FillContent(Transform contentP ,List<Transform> transformsList ) {
        transformsList.Clear();
        foreach (Transform child in contentP) {
            transformsList.Add(child);
        }
    }
}
