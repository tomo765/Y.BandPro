using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoPresenter
{
    private GameInfoUI m_GameInfoUI;
    private float m_MaxSoundTime;
    private RankStatus m_TargetRank;

    public GameInfoPresenter(GameInfoUI gameInfoUI)
    {
        m_GameInfoUI = gameInfoUI;
    }

    public void Start()
    {
        GameDataManager.Instance.GameInfoModel.SetMoneyText();
        GameDataManager.Instance.GameInfoModel.SetTargetRankText();
        GameDataManager.Instance.GameInfoModel.SetTimerSliderValue();
    }

    public void FixedUpdate()
    {
        GameDataManager.Instance.GameInfoModel.SetMoneyText();
        GameDataManager.Instance.GameInfoModel.SetTimerSliderValue();
    }
}
