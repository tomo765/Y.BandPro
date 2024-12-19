using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerRegisterGroup : SelectableGroupBase
{
    private PlayerManager[] m_Players;
    private List<PlayerInput> m_Gamepads = new List<PlayerInput>();


    private ReselectNodeContainer m_ToPlayerCount;

    [SerializeField] private CommonSelectableButton m_ReturnPlayerCountButton;

    public CommonSelectableButton ReturnPlayerCountButton => m_ReturnPlayerCountButton;
    public override ISelectableUI GetInitSelect() => m_ReturnPlayerCountButton;

    void Start()
    {
        SetReturnPlayerCountButton();
    }
    private void OnEnable()
    {
        m_Gamepads = DeviceConnectUpdater.Instance.ReceiveInputs?.GetPlayerInputAs<Gamepad>().ToList();
        InputSystem.onDeviceChange += OnDeviceAdded;
        InputSystem.onDeviceChange += OnDeviceRemoved;
    }
    private void OnDisable()
    {
        m_Gamepads = null;
        InputSystem.onDeviceChange -= OnDeviceAdded;
        InputSystem.onDeviceChange -= OnDeviceRemoved;
    }

    private void Update()
    {
        RegisterPlayer();
    }

    private void SetReturnPlayerCountButton()
    {
        m_ReturnPlayerCountButton.AddPressAction(() =>
        {
            Debug.Log("プレイヤー数選択に戻る");
        });

        m_ToPlayerCount = new ReselectNodeContainer();
        m_Selectables.Add(m_ReturnPlayerCountButton, m_ToPlayerCount);
    }

    private void RegisterPlayer()
    {
        int[] nullIndex = GetNullIndex();
        if (nullIndex.Length == 0) { return; }

        var registrants = GetRegistrants();
        if(registrants.Length > 0)
        Debug.Log(registrants.Length);

        registrants.Select(registrant => m_Players.Select(player => player.Observer).Contains(registrant));


        for (int i = 0; i < registrants.Length; i++)
        {
            for (int j = 0; j < m_Players.Length; j++)
            {
                if (m_Players[i] != null) { break; }
                if (m_Players[i] == m_Players[j]) { continue; }
            }
        }

        int[] GetNullIndex()
        {
            List<int> emptyIndex = new List<int>(4);
            for(int i = 0; i < m_Players.Length; i++)
            {
                if (m_Players[i] != null) { continue; }
                emptyIndex.Add(i);
            }

            return emptyIndex.ToArray();
        }
    }

    private PlayerInputObserver[] GetRegistrants()
    {
        var observers = m_Gamepads.ToArray().GetObservers();
        return observers.Where(observer => observer.GetButtonDown(InputActions.InputSettings.UI.Regist)).ToArray();
    }

    private void OnDeviceAdded(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Added) { return; }
        if(device is Gamepad gamepad)
        {
            m_Gamepads.Add(DeviceConnectUpdater.Instance.ReceiveInputs[gamepad]);
        }
    }

    private void OnDeviceRemoved(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Removed) { return; }
        if (device is Gamepad gamepad)
        {
            m_Gamepads.Remove(DeviceConnectUpdater.Instance.ReceiveInputs[gamepad]);
        }
    }

    public void SetPlayerManagerCount(int playerCount) => m_Players = new PlayerManager[playerCount];
}
