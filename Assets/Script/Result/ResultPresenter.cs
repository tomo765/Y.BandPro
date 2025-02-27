using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultPresenter
{
    private ResultUI m_ResultUI;

    public ResultPresenter(ResultUI resultUI)
    {
        m_ResultUI = resultUI;
    }

    public void Start()
    {
        m_ResultUI.RetryButton.onClick = async () =>
        {
            await FadeUI.Instance.Fade("GameMain");
        };

        m_ResultUI.TitleButton.onClick = async () =>
        {
            await FadeUI.Instance.Fade("Title");
        };

        m_ResultUI.ScoreText.text = "ÉXÉRÉA : " + ResultModel.Score.ToString("N0");
        m_ResultUI.ResultText.text = ResultModel.GetSuccessText();
    }
}
