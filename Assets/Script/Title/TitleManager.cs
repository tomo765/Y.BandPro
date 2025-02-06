using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingletonBehaviour<TitleManager>
{
    [SerializeField] private TitleUI m_TitleUI;
    [SerializeField] private ReserveUI m_ReserveUI;

    private TitlePresenter m_TitlePresenter;

    public TitleUI TitleUI => m_TitleUI;
    public ReserveUI ReserveUI => m_ReserveUI;

    protected override void Awake()
    {
        base.Awake();
        m_TitlePresenter = new TitlePresenter(this);
    }

    private void Start()
    {
        m_TitlePresenter.Start();
    }
}
    
    