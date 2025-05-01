using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T>
{
    private static T instance;

    public static T Instance => instance;

    protected virtual void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Initialize(this as T);
    }

    private void Initialize(T inst) => instance = inst;

    private void OnDestroy()
    {
        if(instance != this) { return; }
        instance = null;
    }
}