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

        InputSystem.onDeviceChange += OnDeviceAdded;      //デバイスを刺したとき
        InputSystem.onDeviceChange += OnDeviceRemoved;    //デバイスを抜いたとき
    }

    private void InitPlayerInput()                              //PlayerInputの初期化
    {
        for (int i = 0; i < InputSystem.devices.Count; i++)     //接続されてるデバイスの数繰り返す
        {
            CreatePlayerInput(InputSystem.devices[i]);      //PlayerInputを作成
        }
    }

    private void OnDeviceAdded(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Added) { return; }      //changeがAddedじゃないときはreturn
        CreatePlayerInput(device);                      // デバイスが追加された場合は、PlayerInputを作成
    }

    private void OnDeviceRemoved(InputDevice device, InputDeviceChange change)
    {
        if (change != InputDeviceChange.Removed) { return; }    //changeがRemovedじゃないときはreturn

        Destroy(m_Observers[device].gameObject);        //m_ObserversをDestroy
        m_Observers.Remove(device);                     //m_Observerの中のdeviceを削除(参照でおかしくなるから)
    }

    private void CreatePlayerInput(InputDevice device)
    {
        if (m_Observers.ContainsKey(device)) { return; }    //すでにこのデバイスが監視されていたらreturn
        if (device is Mouse) { return; }            //マウスならreturn
        if (device is Pen) { return; }              //ペンならreturn

        var playerInput = PlayerInput.Instantiate(prefab: prehab.gameObject,            //プレハブを配置
                                                  controlScheme: device.GetScheme(),
                                                  pairWithDevice: device);

        playerInput.defaultControlScheme = device.GetScheme();          //デバイスの種類を格納する
        m_Observers.Add(device, playerInput.GetComponent<PlayerInputObserver>());       //m_ObserverのなかにdeviceとPlayerInputObserverを格納
        playerInput.transform.SetParent(transform);             //PlayerInputをこのオブジェクトの子オブジェクトにする
    }

    private void OnDestroy()
    {
        InputSystem.onDeviceChange -= OnDeviceAdded;        // デバイスが追加されたときのイベントを解除
        InputSystem.onDeviceChange -= OnDeviceRemoved;      // デバイスが削除されたときのイベントを解除
    }


    public PlayerInputObserver[] GetObserversByButtonDown(string key)       // m_Observers辞書から各PlayerInputObserverを取り出し、ボタンが押されたものだけをフィルタリング
        => m_Observers.Select(pair => pair.Value)       // 辞書の各要素からValue（PlayerInputObserver）を取得
                      .Where(observer => observer.GetButtonDown(key))       // その中から指定したボタンが押されたPlayerInputObserverだけをフィルタリング
                      .ToArray();       // 最終的にフィルタリングされたPlayerInputObserverを配列にして返す

    public PlayerInputObserver[] GetPlayerInputObserverAs<T>() where T : InputDevice
        => Observers?.Where(receiver => receiver.Value.Device is T)?.Select(receiver => receiver.Value)?.ToArray();     //メモで図解
}

public static class InputDeviceExtension
{
    public static string GetScheme<T>(this T Scheme) where T : InputDevice
    {
        return (Scheme) switch              // Schemeの型によって分岐するswitch式
        {
            Keyboard => "Keyboard&Mouse",   // キーボードの場合は"Keyboard&Mouse"
            Gamepad => "Gamepad",           // ゲームパッドの場合は"Gamepad"
            Touchscreen => "Touch",         // タッチスクリーンの場合は"Touch"
            _ => ""                         // それ以外の場合は空文字を返す
        };
    }
}