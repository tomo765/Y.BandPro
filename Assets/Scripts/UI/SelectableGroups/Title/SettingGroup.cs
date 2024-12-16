using Nakaya.UI;
using UnityEngine;

public class SettingGroup : SelectableGroupBase
{
    private ReselectNodeContainer m_ReturnTitleReselect;
    private ReselectNodeContainer m_ExitReselect;

    [SerializeField] private CommonSelectableButton m_ReturnTitleButton;
    [SerializeField] private CommonSelectableButton m_ExitButton;

    public CommonSelectableButton ReturnTitleButton => m_ReturnTitleButton;
    public CommonSelectableButton ExitButton => m_ExitButton;

    public override ISelectableUI GetInitSelect() => m_ReturnTitleButton;


    void Start()
    {
        SetTitleButton();
        SetExitButton();

        UnselectFireActions = new UnselectFireAction(onCancel: () => m_ReturnTitleButton.Press());
    }

    private void SetTitleButton()
    {
        m_ReturnTitleButton.AddPressAction(() =>
        {
            Debug.Log("Return to Title");
        });

        m_ReturnTitleReselect = new ReselectNodeContainer(top: new ReselectNode(m_ExitButton), bottom: new ReselectNode(m_ExitButton));
        m_Selectables.Add(m_ReturnTitleButton, m_ReturnTitleReselect);
    }

    private void SetExitButton()
    {
        m_ExitButton.AddPressAction(() =>
        {
            Debug.Log("Exit");
            
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
        });

        m_ExitReselect = new ReselectNodeContainer(top: new ReselectNode(m_ReturnTitleButton), bottom: new ReselectNode(m_ReturnTitleButton));
        m_Selectables.Add(m_ExitButton, m_ExitReselect);
    }


    void Update()
    {
        
    }
}
