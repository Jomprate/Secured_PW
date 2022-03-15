using UnityEngine;

public static class SetNewParent
{
    public static void SetNP(Transform newParent, GameObject go)
    {
        go.transform.SetParent(newParent);
    }
}
