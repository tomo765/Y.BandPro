using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary> デバイスの接続状況を監視するクラス </summary>
[AddComponentMenu("Scripts/DeviceUpdater")]
public class DeviceConnectUpdater : SingletonBehaviour<DeviceConnectUpdater>
{
    private Dictionary<InputDevice, PlayerInputObserver> m_Observers = new Dictionary<InputDevice, PlayerInputObserver>();

    [SerializeField] private PlayerInput prehab;

    public Dictionary<InputDevice, PlayerInputObserver> Observers => m_Observers;


    protected override void Awake()
    {
        base.Awake();
        if (Instance != this) { return; }
        InitPlayerInput();

        InputSystem.onDeviceChange += OnDeviceAdded;
        InputSystem.onDeviceChange += OnDeviceRemoved;
    }

    private void InitPlayerInput()
    {
        for (int i = 0; i < InputSystem.devices.Count; i++)
        {
            CreatePlayerInput(InputSystem.devices[i]);
        }
    }

    private void OnDeviceAdded(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Added) { return; }
        CreatePlayerInput(device);
    }

    private void OnDeviceRemoved(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Removed) { return; }

        Destroy(m_Observers[device].gameObject);
        m_Observers.Remove(device);
    }

    private void CreatePlayerInput(InputDevice device)
    {
        if (m_Observers.ContainsKey(device)) { return; }
        if (device is Mouse) { return; }
        if (device is Pen) { return; }

        var playerInput = PlayerInput.Instantiate(prefab: prehab.gameObject,
                                                  controlScheme: device.GetScheme(),
                                                  pairWithDevice: device);

        playerInput.defaultControlScheme = device.GetScheme();
        m_Observers.Add(device, playerInput.GetComponent<PlayerInputObserver>());
        playerInput.transform.SetParent(transform);
    }

    private void OnDestroy()
    {
        InputSystem.onDeviceChange -= OnDeviceAdded;
        InputSystem.onDeviceChange -= OnDeviceRemoved;
    }


    public PlayerInputObserver[] GetObserversByButtonDown(string key)
        => m_Observers.Where(observer => observer.Value.GetButtonDown(key))
                      .Select(observer => observer.Value)
                      .ToArray();

    public PlayerInputObserver[] GetPlayerInputObserverAs<T>() where T : InputDevice
        => Observers.Where(receiver => receiver.Value.Device is T).Select(receiver => receiver.Value).ToArray();
}

public static class InputDeviceExtension
{
    public static string GetScheme<T>(this T Scheme) where T : InputDevice
    {
        return (Scheme) switch
        {
            Keyboard => "Keyboard&Mouse",
            Gamepad => "Gamepad",
            Touchscreen => "Touch",
            _ => ""
        };
    }
}