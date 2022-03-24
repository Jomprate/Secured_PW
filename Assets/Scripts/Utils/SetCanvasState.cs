using UnityEngine;

public static class SetCanvasState
{
    public static void SetState(bool state, CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = state ? 1 : 0;
        canvasGroup.blocksRaycasts = state;
        canvasGroup.interactable = state;
    }
    
}
