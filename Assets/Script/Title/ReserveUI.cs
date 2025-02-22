using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReserveUI : UIBase
{
    private ReservePresenter m_ReservePresenter;

    [SerializeField] private MyButton m_PlayButton;
    [SerializeField] private MyButton m_BackButton;

    public MyButton PlayButton => m_PlayButton;
    public MyButton BackButton => m_BackButton;

    private void Start()
    {
        m_ReservePresenter = new ReservePresenter(this);
        m_ReservePresenter.Start();
    }
}
