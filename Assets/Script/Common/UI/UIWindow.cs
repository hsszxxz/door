using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIWindow : MonoBehaviour
{
    protected CanvasGroup canvasGroup;
    protected virtual void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public virtual void ShutAndOpen(bool flag)
    {
        canvasGroup.alpha = flag ? 1 : 0;
        canvasGroup.interactable = flag;
        canvasGroup.blocksRaycasts = flag;
    }
}

