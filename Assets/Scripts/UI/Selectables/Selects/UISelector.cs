using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UISelector : SingletonBehaviour<UISelector>
{
    private SelectableGroupBase m_SelectGroup;
    private ISelectableUI m_CurrentSelect;
    private ISelectableUI m_PrevSelect;

    private PlayerInputReceiver m_SelectPlayer;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        SetSelectPlayer(DeviceConnectUpdater.Instance.ReceiveInputs.GetPlayerInputAs<Gamepad>()[0].GetComponent<PlayerInputReceiver>());
    }

    void Update()
    {
        if(m_SelectPlayer == null) { return; }

        Reselect(InputActions.InputSettings.UI.Up);
        Reselect(InputActions.InputSettings.UI.Down);
        Reselect(InputActions.InputSettings.UI.Right);
        Reselect(InputActions.InputSettings.UI.Left);

        if (m_SelectPlayer.GetButtonDown(InputActions.InputSettings.UI.Click))
        {
            m_CurrentSelect.Press();
        }
    }

    private void Reselect(string dir)
    {
        if(!m_SelectPlayer.GetButtonDown(dir)) { return; }
        if(!m_SelectGroup.TryReselectUI(dir, m_CurrentSelect, out ISelectableUI nextUI)) { return; }

        m_PrevSelect = m_CurrentSelect;
        m_CurrentSelect = nextUI;

        m_PrevSelect.Deselect();
        m_CurrentSelect.Select();
    }

    public void SetNewSelectGroup(SelectableGroupBase newGroup)
    {
        m_CurrentSelect?.Deselect();
        m_PrevSelect = null;

        m_SelectGroup = newGroup;
        m_CurrentSelect = newGroup.GetInitSelect();
        m_CurrentSelect.Select();
    }

    public void SetSelectPlayer(PlayerInputReceiver newSelectPlayer)
    {
        m_SelectPlayer = newSelectPlayer;
    }
}
