using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    private ResultPresenter m_ResultPresenter;

    [SerializeField] private TMPro.TextMeshProUGUI m_ResultText;
    [SerializeField] private TMPro.TextMeshProUGUI m_ScoreText;
    [SerializeField] private MyButton m_RetryButton;
    [SerializeField] private MyButton m_TitleButton;

    public TMPro.TextMeshProUGUI ResultText => m_ResultText;
    public TMPro.TextMeshProUGUI ScoreText => m_ScoreText;
    public MyButton RetryButton => m_RetryButton;
    public MyButton TitleButton => m_TitleButton;

    private void Awake()
    {
        m_ResultPresenter = new ResultPresenter(this);
    }

    void Start()
    {
        m_ResultPresenter.Start();
    }
}

public static class ResultModel
{
    private static int m_Score;
    private static bool m_IsSuccess = false;

    public static int Score => m_Score;

    public static void SetScore(int score) => m_Score = score;
    public static void SetSuccess(bool success) => m_IsSuccess = success;

    public static string GetSuccessText()
    {
        return m_IsSuccess switch
        {
            true => "‰‰‘t¬Œ÷!!",
            false => "‰‰‘tŽ¸”s..."
        };
    }
}