using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerRegisterGroup : SelectableGroupBase
{
    private PlayerManager[] m_Players;
    private List<PlayerInputObserver> m_Observers = new List<PlayerInputObserver>();

    [SerializeField] private CommonSelectableButton m_ReturnPlayerCountButton;
    [SerializeField] private CommonSelectableButton m_OKButton;

    public CommonSelectableButton ReturnPlayerCountButton => m_ReturnPlayerCountButton;
    public CommonSelectableButton OKButton => m_OKButton;
    public override ISelectableUI GetInitSelect() => m_ReturnPlayerCountButton;

    void Start()
    {
        SetReturnPlayerCountButton();
        SetOKButton();
    }
    private void OnEnable()
    {
        m_Observers = DeviceConnectUpdater.Instance.GetPlayerInputObserverAs<Gamepad>().ToList();
        InputSystem.onDeviceChange += OnDeviceAdded;
        InputSystem.onDeviceChange += OnDeviceRemoved;
    }
    private void OnDisable()
    {
        m_Observers = null;
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

        var ToPlayerCountReselect = new ReselectNodeContainer(right : new(m_OKButton));
        m_Selectables.Add(m_ReturnPlayerCountButton, ToPlayerCountReselect);
    }
    private void SetOKButton()
    {
        m_OKButton.AddPressAction(() =>
        {
            Debug.Log("OK");
            GameManager.SetPlayers(m_Players);
        });

        var OKReselect = new ReselectNodeContainer(left : new(m_ReturnPlayerCountButton));
        m_Selectables.Add(OKButton, OKReselect);
    }

    private void RegisterPlayer()
    {
        int[] nullIndex = GetNullIndex();
        if (nullIndex.Length == 0) { return; }

        var registrants = DeviceConnectUpdater.Instance.GetObserversByButtonDown(InputActions.InputSettings.UI.Regist);
        if (registrants.Length <= 0) { return; }
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
        return m_Observers.Where(observer => observer.GetButtonDown(InputActions.InputSettings.UI.Regist)).ToArray();
    }

    private void OnDeviceAdded(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Added) { return; }
        if(device is Gamepad gamepad)
        {
            m_Observers.Add(DeviceConnectUpdater.Instance.Observers[gamepad]);
        }
    }

    private void OnDeviceRemoved(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Removed) { return; }
        if (device is Gamepad gamepad)
        {
            m_Observers.Remove(DeviceConnectUpdater.Instance.Observers[gamepad]);
        }
    }

    public void SetPlayerManagerCount(int playerCount) => m_Players = new PlayerManager[playerCount];
}
