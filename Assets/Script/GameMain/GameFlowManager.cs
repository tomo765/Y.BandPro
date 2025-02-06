using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : SingletonBehaviour<GameFlowManager>
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        // SoundManagerのインスタンスがあり、かつBGMを再生していないとき
        if (!SoundManager.Instance?.IsPlaySound ?? false)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
