using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfoModel
{
    private int m_Cullenturn = 1;
    private int m_MaxTurn = 3;
    private GameInfoUI m_GameInfoUI;
    private float m_MaxSoundTime;
    private int m_Money = 250;
    private RankStatus m_TargetRank = RankStatus.C;

    public int CullentTurn => m_Cullenturn;
    public int MaxTurn => m_MaxTurn;
    public int Money => m_Money;
    public RankStatus TargetRank => m_TargetRank;

    public GameInfoModel(GameInfoUI gameInfoUI, float maxSoundTime)
    {
        m_GameInfoUI = gameInfoUI;
        m_MaxSoundTime = maxSoundTime;

        gameInfoUI.TimerSlider.maxValue = maxSoundTime;
    }

    public void AddTurn() => m_Cullenturn++;
    public void AddMoney(int val) => m_Money += val;
    public bool TryUseMoney(int val)
    {
        if (m_Money < val) { return false; }
        m_Money -= val;
        return true;
    }

    public void SetTimerSliderValue()
    {
        m_GameInfoUI.TimerSlider.value = m_MaxSoundTime - SoundManager.Instance.MainSoundTime;
    }

    public void SetNextTargetRank()
    {
        m_TargetRank = GetNextTarget(m_Cullenturn + 1);
    }

    public void SetMoneyText()
    {
        m_GameInfoUI.HaveMoneyText.text = "ŠŽ‹à : " + m_Money.ToString("N0");
    }

    public void SetTargetRankText()
    {
        m_GameInfoUI.TargetRankText.text = "–Ú•Wƒ‰ƒ“ƒN : " + m_TargetRank.ToString().Replace("_Plus", "+");
    }

    private RankStatus GetNextTarget(int nextTurn)
    {
        return nextTurn switch
        {
            1 => RankStatus.C,
            2 => RankStatus.B,
            3 => RankStatus.A,
            _ => RankStatus.D
        };
    }
}