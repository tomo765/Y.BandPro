using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    void Update()
    {
        
    }

    private class ResultPresenter
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
}
