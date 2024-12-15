using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Selector : MonoBehaviour
{
    private SelectableGroupBase m_SelectGroup;
    private ISelectableUI m_CurrentSelect;
    private ISelectableUI m_PrevSelect;

    private PlayerInputReceiver m_SelectPlayer;

    void Start()
    {
        m_SelectGroup = GetComponent<SelectableGroupBase>();

        m_CurrentSelect = m_SelectGroup.GetInitSelect();
        m_CurrentSelect.Select();

        Init();
    }

    private void Init()
    {
        m_SelectPlayer = DeviceConnectUpdater.Instance.ReceiveInputs.GetPlayerInputAs<Gamepad>()[0].GetComponent<PlayerInputReceiver>();
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
        //else
        //{
        //    m_CurrentSelect.Release();
        //}
    }

    private void Reselect(string dir)
    {
        if(!m_SelectPlayer.GetButtonDown(dir)) { return; }
        if (!m_SelectGroup.TryReselectUI(dir, m_CurrentSelect, out ISelectableUI nextUI)) { return; }

        m_PrevSelect = m_CurrentSelect;
        m_CurrentSelect = nextUI;

        m_PrevSelect.Deselect();
        m_CurrentSelect.Select();
    }
}
