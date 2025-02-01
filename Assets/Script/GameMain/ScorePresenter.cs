using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePresenter
{
    private ScoreUI m_ScoreUI;
    private ScoreModel m_ScoreModel;

    public ScorePresenter(ScoreUI scoreUI)
    {
        m_ScoreUI = scoreUI;
    }

    public void FixedUpdate()
    {
        m_ScoreUI.RankText.text = "A";
        m_ScoreUI.ScoreText.text = "Score : " + 111;
    }
}
