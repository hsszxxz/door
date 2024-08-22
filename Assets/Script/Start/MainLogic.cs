using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MainLogic : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.GetUIWindow<MainUIWindow>().ShutAndOpen(true);
    }
}

