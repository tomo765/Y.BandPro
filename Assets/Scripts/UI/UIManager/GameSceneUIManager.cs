using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameSceneUIManager : MonoBehaviour
{
    [SerializeField] private HomeGroup m_HomeGroup;


    void Start()
    {
        UISelector.Instance.SetNewDeviceOnRemove = () =>
        {
            var observers = DeviceConnectUpdater.Instance.GetPlayerInputObserverAs<Gamepad>();
            return observers.Length != 0 ? observers[0] : null;
        };
        UISelector.Instance.SetNewSelectGroup(m_HomeGroup);
    }


    void Update()
    {
        
    }
}
