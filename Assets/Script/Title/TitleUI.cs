using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : UIBase
{
    private TitlePresenter m_TitlePresenter;

    [SerializeField] private MyButton m_StartButton;

    public MyButton StartButton => m_StartButton;

    private void Start()
    {
        m_TitlePresenter = new TitlePresenter(this);
        m_TitlePresenter.Start();
    }
}
