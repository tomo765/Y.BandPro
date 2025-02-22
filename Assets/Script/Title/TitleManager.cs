using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingletonBehaviour<TitleManager>
{
    [SerializeField] private TitleUI m_TitleUI;
    [SerializeField] private ReserveUI m_ReserveUI;

    public TitleUI TitleUI => m_TitleUI;
    public ReserveUI ReserveUI => m_ReserveUI;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        InitTitleUI();
        InitReserveUI();
    }

    private void InitTitleUI()
    {
        m_TitleUI.SetActive(true);
        m_TitleUI.StartButton.onClick += () =>
        {
            m_ReserveUI.SetActive(true);
        };
    }
    private void InitReserveUI()
    {
        m_ReserveUI.SetActive(false);
        m_ReserveUI.BackButton.onClick += () =>
        {
            m_TitleUI.SetActive(true);
        };
    }
}
    
    