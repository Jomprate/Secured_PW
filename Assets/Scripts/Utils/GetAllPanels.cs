using UnityEngine;

public class GetAllPanels : MonoBehaviour
{
    public CanvasV[] CanvasV { get; set; }
    public void Initialize() {
        CanvasV = GetComponentsInChildren<CanvasV>();
    }
}
