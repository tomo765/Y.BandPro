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
    private Dictionary<InputDevice, PlayerInput> m_ReceiveInputObjects = new Dictionary<InputDevice, PlayerInput>();

    [SerializeField] private PlayerInput prehab;

    public Dictionary<InputDevice, PlayerInput> ReceiveInputs => m_ReceiveInputObjects;


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

        Destroy(m_ReceiveInputObjects[device].gameObject);
        m_ReceiveInputObjects.Remove(device);
    }

    private void CreatePlayerInput(InputDevice device)
    {
        if (m_ReceiveInputObjects.ContainsKey(device)) { return; }
        if (device is Mouse) { return; }
        if (device is Pen) { return; }

        var playerInput = PlayerInput.Instantiate(prefab: prehab.gameObject,
                                                  controlScheme: device.GetScheme(),
                                                  pairWithDevice: device);

        playerInput.defaultControlScheme = device.GetScheme();
        m_ReceiveInputObjects.Add(device, playerInput);
        playerInput.transform.SetParent(transform);
    }

    private void OnDestroy()
    {
        InputSystem.onDeviceChange -= OnDeviceAdded;
        InputSystem.onDeviceChange -= OnDeviceRemoved;
    }
}

public static class InputDeviceExtension
{
    #region PlayerInputの設定
    public static string GetScheme<T>(this T Scheme) where T : InputControl
    {
        return (Scheme) switch
        {
            Keyboard => "Keyboard&Mouse",
            Gamepad => "Gamepad",
            Touchscreen => "Touch",
            _ => ""
        };
    }
    #endregion

    public static PlayerInput[] GetPlayerInputAs<T>(this Dictionary<InputDevice, PlayerInput> receiver) where T : InputDevice
        => receiver.Where(keyValues => keyValues.Value.devices[0] is T).Select(keyValues => keyValues.Value).ToArray();

    public static PlayerInputObserver[] GetObservers(this PlayerInput[] inputs)
         => inputs.Select(input => input.GetComponent<PlayerInputObserver>()).ToArray();
}