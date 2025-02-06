using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoModel
{
    private GameInfoUI m_GameInfoUI;
    private float m_MaxSoundTime;
    private int m_Money;
    private RankStatus m_TargetRank;

    public int Money => m_Money;

    public GameInfoModel(GameInfoUI gameInfoUI, float maxSoundTime)
    {
        m_GameInfoUI = gameInfoUI;
        m_MaxSoundTime = maxSoundTime;

        gameInfoUI.TimerSlider.maxValue = maxSoundTime;
    }

    public void SetTimerSliderValue()
    {
        m_GameInfoUI.TimerSlider.value = m_MaxSoundTime - SoundManager.Instance.MainSoundTime;
    }

    public void SetMoneyText()
    {
        m_GameInfoUI.HaveMoneyText.text = "Money : " + GameDataManager.Instance.GameInfoModel.m_Money.ToString();
    }

    public void SetTargetRankText()
    {
        m_GameInfoUI.TargetRankText.text = "TargetRank : " + m_TargetRank.ToString().Replace("_Plus", "+");
    }
}
