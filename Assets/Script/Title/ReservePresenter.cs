using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReservePresenter
{
    private ReserveUI m_ReserveUI;

    private ReservePresenter() { }
    public ReservePresenter(ReserveUI reseveUI)
    {
        m_ReserveUI = reseveUI;
    }

    public void Start()
    {
        m_ReserveUI.PlayButton.onClick += async () =>
        {
            await FadeUI.Instance.Fade("GameMain");
        };

        m_ReserveUI.BackButton.onClick += () =>
        {
            m_ReserveUI.gameObject.SetActive(false);
        };
    }
}
