using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<T>();
                if (instance == null)
                {
                    new GameObject("Singleton of" + typeof(T)).AddComponent<T>();
                }
                else
                {
                    instance.Init();
                }
            }
            return instance;
        }
    }
    protected void Awake()
    {
        if (instance == null)
        {
            instance = this as T;
            Init();
        }
    }
    public virtual void Init()
    { }
}

