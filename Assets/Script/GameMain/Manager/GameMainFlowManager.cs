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

        GameObject fadeUI = (GameObject)Resources.Load("FadeOutUI");
        Instantiate(fadeUI, new Vector3(0f, 0f, 0f), Quaternion.identity);
        FadeUI.Instance.gameObject.SetActive(false);
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

    public async void FinishPerformance()
    {
        if((int)GameDataManager.Instance.GameInfoModel.TargetRank > (int)GameDataManager.Instance.ScoreModel.RankStatus)
        {
            FadeUI.Instance.gameObject.SetActive(true);

            await FadeUI.Instance.Fade("Result", () => FadeUI.Instance.gameObject.SetActive(false));
            return;
        }
        if(GameDataManager.Instance.GameInfoModel.CullentTurn >= 3)
        {
            FadeUI.Instance.gameObject.SetActive(true);

            await FadeUI.Instance.Fade("Result", () => FadeUI.Instance.gameObject.SetActive(false));
            return;
        }


        GameDataManager.Instance.GameInfoModel.AddTurn();
        SoundManager.Instance.StartMainSound().Forget();
        SoundManager.Instance.StartPlaySounds();
    }
}
