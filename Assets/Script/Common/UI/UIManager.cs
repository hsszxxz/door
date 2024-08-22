using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIManager : MonoSingleton<UIManager>
{
    private Dictionary<string, UIWindow> UIWindowDic;
    public override void Init()
    {
        base.Init();
        UIWindowDic = new Dictionary<string, UIWindow>();
        UIWindow[] uiWindows = FindObjectsByType<UIWindow>(FindObjectsSortMode.None);
        foreach (UIWindow uiWindow in uiWindows)
        {
            UIWindowDic.Add(uiWindow.GetType().Name, uiWindow);
        }
    }
    public T GetUIWindow<T>() where T : class
    {
        string name = typeof(T).Name;
        if (UIWindowDic.ContainsKey(name))
        {
            return UIWindowDic[name] as T;
        }
        else
        {
            return null;
        }
    }
}


