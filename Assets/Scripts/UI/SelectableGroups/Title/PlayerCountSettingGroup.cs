using Nakaya.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCountSettingGroup : SelectableGroupBase
{
    private ReselectNodeContainer m_Player2Reselect;
    private ReselectNodeContainer m_Player3Reselect;
    private ReselectNodeContainer m_Player4Reselect;
    private ReselectNodeContainer m_ReturnTitleReselect;

    [SerializeField] private CommonSelectableButton m_Player2Button;
    [SerializeField] private CommonSelectableButton m_Player3Button;
    [SerializeField] private CommonSelectableButton m_Player4Button;
    [SerializeField] private CommonSelectableButton m_ReturnTitleButton;

    public CommonSelectableButton Player2Button => m_Player2Button;
    public CommonSelectableButton Player3Button => m_Player3Button;
    public CommonSelectableButton Player4Button => m_Player4Button;
    public CommonSelectableButton ReturnTitleButton => m_ReturnTitleButton;


    public override ISelectableUI GetInitSelect() => m_Player2Button;


    void Start()
    {
        SetPlayer2Button();
        SetPlayer3Button();
        SetPlayer4Button();
        SetReturnTitleButton();
    }

    private void SetPlayer2Button()
    {
        m_Player2Button.AddPressAction(() =>
        {
            Debug.Log("2人プレイ");
        });

        m_Player2Reselect = new ReselectNodeContainer(right : new(m_Player3Button), left : new(m_Player4Button), bottom : new(m_ReturnTitleButton));
        m_Selectables.Add(m_Player2Button, m_Player2Reselect);
    }

    private void SetPlayer3Button()
    {
        m_Player3Button.AddPressAction(() =>
        {
            Debug.Log("3人プレイ");
        });

        m_Player3Reselect = new ReselectNodeContainer(right: new(m_Player4Button), left: new(m_Player2Button), bottom: new(m_ReturnTitleButton));
        m_Selectables.Add(m_Player3Button, m_Player3Reselect);
    }

    private void SetPlayer4Button()
    {
        m_Player4Button.AddPressAction(() =>
        {
            Debug.Log("4人プレイ");
        });

        m_Player4Reselect = new ReselectNodeContainer(right: new(m_Player2Button), left: new(m_Player3Button), bottom: new(m_ReturnTitleButton));
        m_Selectables.Add(m_Player4Button, m_Player4Reselect);
    }

    private void SetReturnTitleButton()
    {
        m_ReturnTitleButton.AddPressAction(() =>
        {
            Debug.Log("タイトルに戻る");
        });

        m_ReturnTitleReselect = new ReselectNodeContainer(top: new(m_Player2Button));
        m_Selectables.Add(m_ReturnTitleButton, m_ReturnTitleReselect);
    }
}
