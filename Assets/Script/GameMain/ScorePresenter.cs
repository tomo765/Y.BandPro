using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePresenter
{
    private ScoreUI m_ScoreUI;

    public ScorePresenter(ScoreUI scoreUI)
    {
        GameDataManager.Instance.InitScoreModel();
        m_ScoreUI = scoreUI;
    }

    public void FixedUpdate()
    {
        m_ScoreUI.RankText.text = GameDataManager.Instance.ScoreModel.Rank;
        m_ScoreUI.ScoreText.text = "Score : " + GameDataManager.Instance.ScoreModel.Score.ToString("N0");
    }
}
