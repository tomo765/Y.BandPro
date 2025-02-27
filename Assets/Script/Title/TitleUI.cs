using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUI : UIBase
{
    private TitlePresenter m_TitlePresenter;

    [SerializeField] private MyButton m_StartButton;
    [SerializeField] private UnityEngine.UI.Slider m_VolumeSlider;

    public MyButton StartButton => m_StartButton;
    public UnityEngine.UI.Slider VolumeSlider => m_VolumeSlider;

    private void Start()
    {
        m_TitlePresenter = new TitlePresenter(this);
        m_TitlePresenter.Start();
    }
}
