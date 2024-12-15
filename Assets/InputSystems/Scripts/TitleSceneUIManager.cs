using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneUIManager : MonoBehaviour
{
    [SerializeField] private TitleGroup m_TitleGroup;
    [SerializeField] private SettingGroup m_SettingGroup;
    [SerializeField] private PlayerConnectGroup m_PlayerConnectGroup;

    void Start()
    {
        SetTitleGroup();
        SetSettingGroup();
        SetPlayerConnectGroup();
        SetGroupsActive();
    }

    private void SetGroupsActive()
    {
        m_TitleGroup.gameObject.SetActive(true);
        m_SettingGroup.gameObject.SetActive(false);
        m_PlayerConnectGroup.gameObject.SetActive(false);
    }

    private void SetTitleGroup()
    {
        m_TitleGroup.PlayGameButton.AddPressAction(() =>
        {
            m_TitleGroup.gameObject.SetActive(false);
            m_PlayerConnectGroup.gameObject.SetActive(true);
        });

        m_TitleGroup.SettingsButton.AddPressAction(() =>
        {
            m_TitleGroup.gameObject.SetActive(false);
            m_SettingGroup.gameObject.SetActive(true);
        });
    }

    private void SetSettingGroup()
    {
        m_SettingGroup.ReturnTitleButton.AddPressAction(() =>
        {
            m_SettingGroup.gameObject.SetActive(false);
            m_TitleGroup.gameObject.SetActive(true);
        });
    }

    private void SetPlayerConnectGroup()
    {
        m_PlayerConnectGroup.ReturnTitleButton.AddPressAction(() =>
        {
            m_PlayerConnectGroup.gameObject.SetActive(false);
            m_TitleGroup.gameObject.SetActive(true);
        });
    }
}
