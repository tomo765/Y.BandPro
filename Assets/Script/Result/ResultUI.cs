using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    private ResultPresenter m_ResultPresenter;

    [SerializeField] private MyButton m_RetryButton;
    [SerializeField] private MyButton m_TitleButton;

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
