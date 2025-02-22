using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameMainFlowManager : SingletonBehaviour<GameMainFlowManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        OnStart().Forget();
        SoundManager.Instance.OnFinishMainSound.AddListener(() => FinishPerformance().Forget());
    }

    private void FixedUpdate()
    {

    }

    private async UniTask OnStart()
    {
        await UniTask.WaitUntil(() => FadeUI.Instance.IsFadeOut);
        SoundManager.Instance.StartMainSound().Forget();
    }

    public async UniTask FinishPerformance()
    {
        if(!GameDataManager.Instance.IsSuccessTurn || !GameDataManager.Instance.IsDoableNextTuen)
        {
            await FadeUI.Instance.Fade("Result");
            return;
        }

        GameDataManager.Instance.GameInfoModel.AddTurn();
        SoundManager.Instance.StartMainSound().Forget();
        SoundManager.Instance.StartPlaySounds();
    }
}
