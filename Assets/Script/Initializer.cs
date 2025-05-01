using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    private static bool IsInitialized = false;

    [SerializeField] private FadeUI m_FadeUIPrehab;


    private void Awake()
    {
        Initialize();
        Destroy(gameObject);
    }


    // すべてのシーン上で使用するオブジェクトの生成などの初期化をする
    private void Initialize()
    {
        if (IsInitialized) { return; }
        IsInitialized = true;

        var fadeUI = Instantiate(m_FadeUIPrehab);
    }
}
