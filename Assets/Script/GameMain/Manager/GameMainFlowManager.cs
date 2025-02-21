using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameMainFlowManager : SingletonBehaviour<GameMainFlowManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        OnStart().Forget();
        SoundManager.Instance.OnFinishMainSound.AddListener(FinishPerformance);
    }

    private void FixedUpdate()
    {

    }

    private async UniTask OnStart()
    {
        await UniTask.WaitUntil(() => FadeUI.Instance.IsFadeOut);
        SoundManager.Instance.StartMainSound().Forget();
    }

    public void FinishPerformance()
    {
        if((int)GameDataManager.Instance.GameInfoModel.TargetRank > (int)GameDataManager.Instance.ScoreModel.RankStatus)
        {
            SceneManager.LoadScene("Result");
            return;
        }
        if(GameDataManager.Instance.GameInfoModel.CullentTurn >= 3)
        {
            SceneManager.LoadScene("Result");
            return;
        }


        GameDataManager.Instance.GameInfoModel.AddTurn();
        SoundManager.Instance.StartMainSound().Forget();
        SoundManager.Instance.StartPlaySounds();
    }
}
