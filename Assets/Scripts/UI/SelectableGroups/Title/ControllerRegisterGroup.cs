using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//接続が解除されたコントローラーの Observerクラスは同時に削除される仕様なので
//自動的にm_Observersの指定の値も nullになる?


public class ControllerRegisterGroup : SelectableGroupBase
{
    int m_PlayerCount;
    private PlayerManager[] m_Players = null;
    /// <summary>  </summary>
    private PlayerInputObserver[] m_Observers;

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

    private void Update()
    {
        PreregisterPlayer();
    }

    private void SetReturnPlayerCountButton()
    {
        m_ReturnPlayerCountButton.AddPressAction(() =>
        {
            Debug.Log("プレイヤー数選択に戻る");
            m_Players = null;
            m_Observers = null;
        });

        var ToPlayerCountReselect = new ReselectNodeContainer(right : new(m_OKButton));
        m_Selectables.Add(m_ReturnPlayerCountButton, ToPlayerCountReselect);
    }
    private void SetOKButton()
    {
        m_OKButton.AddPressAction(() =>
        {
            Debug.Log("OK");
            var players = m_Observers.Select((observer, index) => new PlayerManager(index, observer)).ToArray();
            GameManager.SetPlayers(m_Players);
        });

        m_OKButton.SetEnable(GetNullIndex().Length == 0);
        m_OKButton.SetEnableCondition(() => GetNullIndex().Length == 0);
        var OKReselect = new ReselectNodeContainer(left : new(m_ReturnPlayerCountButton));
        m_Selectables.Add(OKButton, OKReselect);
    }

    /// <summary> 前登録 </summary>
    private void PreregisterPlayer()
    {
        int[] nullIndex = GetNullIndex();
        if (nullIndex.Length == 0) { return; }

        var registrants = DeviceConnectUpdater.Instance.GetObserversByButtonDown(InputActions.InputSettings.UI.Regist);
        if (registrants.Length <= 0) { return; }
        var unregistrants = registrants.Where(registrant => !m_Observers.Contains(registrant)).ToArray();
        if(unregistrants.Length <= 0) { return; }
        Debug.Log("Do register");

        for (int i = 0; i < unregistrants.Length; i++)
        {
            for (int j = 0; j < m_Observers.Length; j++)
            {
                if (m_Observers[j] != null) { continue; }
                m_Observers[j] = unregistrants[i];
                break;
            }
        }
        m_OKButton.SetEnable(GetNullIndex().Length == 0);
    }
    private int[] GetNullIndex()
    {
        List<int> emptyIndex = new List<int>(m_PlayerCount);
        for (int i = 0; i < m_Observers.Length; i++)
        {
            if (m_Observers[i] != null) { continue; }
            emptyIndex.Add(i);
        }

        return emptyIndex.ToArray();
    }


    public void SetPlayerCount(int playerCount)
    {
        m_PlayerCount = playerCount;
        m_Players = new PlayerManager[playerCount];
        m_Observers = new PlayerInputObserver[playerCount];
    }
}
