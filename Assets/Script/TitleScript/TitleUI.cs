using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : UIBase
{
    [SerializeField] private Button m_StartButton;

    public Button StartButton => m_StartButton;

    private void Start()
    {
        TitleManager.Instance.SetTitleUI(this);
    }
}
