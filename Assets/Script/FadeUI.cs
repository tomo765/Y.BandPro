using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FadeUI : SingletonBehaviour<FadeUI>
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1.0f;

    public bool IsFadeOut => fadeImage.color.a <= 0;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);

        gameObject.SetActive(false);
    }

    private float fadeTime = 0.5f;
    private const int FrameRate = 60;
    private const int WaitDelay = 1000 / FrameRate;  // 1秒 / フレームレート

    public async UniTask Fade(string newSceneName, System.Action OnFinishFade = null)
    {
        gameObject.SetActive(true);

        await FadeIn(fadeTime);
        await SceneManager.LoadSceneAsync(newSceneName);
        await FadeOut(fadeTime);

        OnFinishFade?.Invoke();
        gameObject.SetActive(false);
    }


    private async UniTask FadeIn(float time)
    {
        Color cl = fadeImage.color;
        var fadeDuration = GetFadeDuration(time);

        while (fadeImage.color.a < 1)
        {
            cl.a += fadeDuration;
            fadeImage.color = cl;
            await UniTask.Delay(WaitDelay);
        }
    }

    private async UniTask FadeOut(float time)
    {
        Color cl = fadeImage.color;
        var fadeDuration = GetFadeDuration(time);

        while (fadeImage.color.a > 0)
        {
            cl.a -= fadeDuration;
            fadeImage.color = cl;
            await UniTask.Delay(WaitDelay);
        }
    }

    private float GetFadeDuration(float time) => 1 / (float)FrameRate / time;
}
