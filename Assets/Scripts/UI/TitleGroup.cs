using Nakaya.UI;
using UnityEngine;

public class TitleGroup : SelectableGroupBase
{
    private ReselectNodeContainer m_PlayGameReselect;
    private ReselectNodeContainer m_SettingsReselect;

    [SerializeField] private CommonSelectableButton m_PlayGameButton;
    [SerializeField] private CommonSelectableButton m_SettingsButton;

    public CommonSelectableButton PlayGameButton => m_PlayGameButton;
    public CommonSelectableButton SettingsButton => m_SettingsButton;

    public override ISelectableUI GetInitSelect() => m_PlayGameButton;

    void Start()
    {
        SetTitleButton();
        SetSettingsButton();
    }

    private void SetTitleButton()
    {
        m_PlayGameButton.AddPressAction(() =>
        {
            Debug.Log("Play");
        });

        m_PlayGameReselect = new ReselectNodeContainer(top: new ReselectNode(m_SettingsButton), bottom: new ReselectNode(m_SettingsButton));
        m_Selectables.Add(m_PlayGameButton, m_PlayGameReselect);
    }

    private void SetSettingsButton()
    {
        m_SettingsButton.AddPressAction(() =>
        {
            Debug.Log("Setting");
        });

        m_SettingsReselect = new ReselectNodeContainer(top: new ReselectNode(m_PlayGameButton), bottom: new ReselectNode(m_PlayGameButton));
        m_Selectables.Add(m_SettingsButton, m_SettingsReselect);
    }
}
