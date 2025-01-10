using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneUIManager : MonoBehaviour
{
    [SerializeField] private TitleGroup m_TitleGroup;
    [SerializeField] private SettingGroup m_SettingGroup;
    [SerializeField] private PlayerCountSettingGroup m_PlayerConnectGroup;
    [SerializeField] private ControllerRegisterGroup m_ControllerRegisterGroup;
    [SerializeField] private ConfirmPlayerGroup m_ConfirmPlayerGroup;

    void Start()
    {
        UISelector.Instance.SetNewDeviceOnRemove = () =>
        {
            var observers = DeviceConnectUpdater.Instance.GetPlayerInputObserverAs<Gamepad>();
            return observers.Length != 0 ? observers[0] : null;
        };
        UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

        SetTitleGroup();
        SetSettingGroup();
        SetPlayerConnectGroup();
        SetGroupsActive();
        SetControllerRegister();
        SetConfirmPlayerGroup();
    }

    private void SetGroupsActive()
    {
        m_TitleGroup.SetActive(true);
        m_SettingGroup.SetActive(false);
        m_PlayerConnectGroup.SetActive(false);
        m_ControllerRegisterGroup.SetActive(false);
        m_ConfirmPlayerGroup.SetActive(false);
    }

    private void SetTitleGroup()
    {
        m_TitleGroup.PlayGameButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_PlayerConnectGroup);

            m_TitleGroup.SetActive(false);
            m_PlayerConnectGroup.SetActive(true);
        });

        m_TitleGroup.SettingsButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_SettingGroup);

            m_TitleGroup.SetActive(false);
            m_SettingGroup.SetActive(true);
        });
    }

    private void SetSettingGroup()
    {
        m_SettingGroup.ReturnTitleButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

            m_SettingGroup.SetActive(false);
            m_TitleGroup.SetActive(true);
        });
    }

    private void SetPlayerConnectGroup()
    {
        m_PlayerConnectGroup.Player2Button.AddPressAction(() => 
        {
            UISelector.Instance.SetNewSelectGroup(m_ControllerRegisterGroup);

            m_ControllerRegisterGroup.SetPlayerCount(2);
            m_PlayerConnectGroup.SetActive(false);
            m_ControllerRegisterGroup.SetActive(true);
        });
        m_PlayerConnectGroup.Player3Button.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_ControllerRegisterGroup);

            m_ControllerRegisterGroup.SetPlayerCount(3);
            m_PlayerConnectGroup.SetActive(false);
            m_ControllerRegisterGroup.SetActive(true);
        });
        m_PlayerConnectGroup.Player4Button.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_ControllerRegisterGroup);

            m_ControllerRegisterGroup.SetPlayerCount(4);
            m_PlayerConnectGroup.SetActive(false);
            m_ControllerRegisterGroup.SetActive(true);
        });

        m_PlayerConnectGroup.ReturnTitleButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_TitleGroup);

            m_PlayerConnectGroup.SetActive(false);
            m_TitleGroup.SetActive(true);
        });
    }

    private void SetControllerRegister()
    {
        m_ControllerRegisterGroup.ReturnPlayerCountButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_PlayerConnectGroup);

            m_ControllerRegisterGroup.SetActive(false);
            m_PlayerConnectGroup.SetActive(true);
        });

        m_ControllerRegisterGroup.OKButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_ConfirmPlayerGroup);

            m_ControllerRegisterGroup.SetActive(false);
            m_ConfirmPlayerGroup.SetActive(true);
        });
    }

    private void SetConfirmPlayerGroup()
    {
        m_ConfirmPlayerGroup.OKButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(null);

            UnityEngine.SceneManagement.SceneManager.LoadScene("GameMain");
        });

        m_ConfirmPlayerGroup.NoButton.AddPressAction(() =>
        {
            UISelector.Instance.SetNewSelectGroup(m_ControllerRegisterGroup);

            m_ConfirmPlayerGroup.SetActive(false);
            m_ControllerRegisterGroup.SetActive(true);
        });
    }
}
