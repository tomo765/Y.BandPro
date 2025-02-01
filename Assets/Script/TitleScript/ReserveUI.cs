using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReserveUI : UIBase
{
    [SerializeField] private Button m_PlayButton;
    [SerializeField] private Button m_BackButton;

    public Button PlayButton => m_PlayButton;
    public Button BackButton => m_BackButton;

    private void Start()
    {
        TitleManager.Instance.SetReserveUI(this);
        SetActive(false);
    }
}
