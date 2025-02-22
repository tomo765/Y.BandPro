using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class FadeUI : SingletonBehaviour<FadeUI>
{
    [SerializeField] private Image fadeimage;
    [SerializeField] private float fadeDuration = 1.0f;

    public bool IsFadeOut => fadeimage.color.a <= 0;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public async UniTask Fade(string newSceneName, System.Action OnFinishFade = null)
    {
        await FadeIn();
        SceneManager.LoadScene(newSceneName);
        await FadeOut();

        OnFinishFade?.Invoke();
    }


    private async UniTask FadeIn()
    {
        await UniTask.WaitUntil(() =>
        {
            Color cl = fadeimage.color;
            cl.a += 0.004f;
            fadeimage.color = cl;

            return fadeimage.color.a >= 1;
        });
    }

    private async UniTask FadeOut()
    {
        await UniTask.WaitUntil(() =>
        {
            Color cl = fadeimage.color;
            cl.a -= 0.004f;
            fadeimage.color = cl;

            return fadeimage.color.a <= 0;
        });
    }

    void Update()
    {
        
    }
}
