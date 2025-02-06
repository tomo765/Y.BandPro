using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameFlowManager : SingletonBehaviour<GameFlowManager>
{
    private void FixedUpdate()
    {
        // SoundManagerのインスタンスがあり、かつBGMを再生していないとき
        if (!SoundManager.Instance?.IsPlaySound ?? false)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
