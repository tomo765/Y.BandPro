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
        m_ResultUI.RetryButton.onClick = () =>
        {
            SceneManager.LoadScene("GameMain");
        };

        m_ResultUI.TitleButton.onClick = () =>
        {
            SceneManager.LoadScene("Title");
        };
    }
}
