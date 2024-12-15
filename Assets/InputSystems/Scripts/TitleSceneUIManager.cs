using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneUIManager : MonoBehaviour
{
    [SerializeField] private TitleGroup m_TitleGroup;
    [SerializeField] private SettingGroup m_SettingGroup;
    [SerializeField] private PlayerCountSettingGroup m_PlayerConnectGroup;

    void Start()
    {
        UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

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
            UISelector.Instance.SetNewSelectGroup(m_PlayerConnectGroup);

            m_TitleGroup.gameObject.SetActive(false);
            m_PlayerConnectGroup.gameObject.SetActive(true);
        });

        m_TitleGroup.SettingsButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_SettingGroup);

            m_TitleGroup.gameObject.SetActive(false);
            m_SettingGroup.gameObject.SetActive(true);
        });
    }

    private void SetSettingGroup()
    {
        m_SettingGroup.ReturnTitleButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

            m_SettingGroup.gameObject.SetActive(false);
            m_TitleGroup.gameObject.SetActive(true);
        });
    }

    private void SetPlayerConnectGroup()
    {
        m_PlayerConnectGroup.ReturnTitleButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

            m_PlayerConnectGroup.gameObject.SetActive(false);
            m_TitleGroup.gameObject.SetActive(true);
        });
    }
}
